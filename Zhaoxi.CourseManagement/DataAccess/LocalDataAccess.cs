using LiveCharts.Defaults;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.CourseManagement.Common;
using Zhaoxi.CourseManagement.DataAccess.DataEntity;
using Zhaoxi.CourseManagement.Model;
using System.Collections.ObjectModel;

namespace Zhaoxi.CourseManagement.DataAccess
{
    public class LocalDataAccess
    {
        private static LocalDataAccess instance;

        private LocalDataAccess()
        {

        }

        public static LocalDataAccess GetInstance()
        {
            return instance ?? (instance = new LocalDataAccess());
        }

        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapter;

        private void Dispose()
        {
            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (comm != null)
            {
                comm.Dispose();
                comm = null;
            }
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        private bool DBConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            if (conn == null)
            {
                conn = new SqlConnection(connStr);
            }
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UserEntity CheckUserInfo(string userName, string password)
        {
            try
            {
                if (DBConnection())
                {
                    string userSql = "select * from users where user_name=@UserName and password=@Password and is_validation=1";
                    adapter = new SqlDataAdapter(userSql, conn);
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar) { Value = userName });
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar) { Value = MD5Provider.GetMD5String(password + "@" + userName) });
                    DataTable dt = new DataTable();
                    int count = adapter.Fill(dt);
                    if (count <= 0)
                    {
                        throw new Exception("用户名或密码错误！");
                    }
                    DataRow dr = dt.Rows[0];
                    if (dr.Field<Int32>("is_can_login") == 0)
                    {
                        throw new Exception("当前用户没有权限使用此平台！");
                    }
                    UserEntity userInfo = new UserEntity();
                    userInfo.UserName = dr.Field<string>("user_name");
                    userInfo.RealName = dr.Field<string>("real_name");
                    userInfo.Password = dr.Field<string>("password");
                    userInfo.Avatar = dr.Field<string>("avatar");
                    userInfo.Gender = dr.Field<Int32>("gender");
                    return userInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();

            }
            return null;
        }

        public List<CourseSeriesModel> GetCoursePlanRecord()
        {
            try
            {
                List<CourseSeriesModel> cModelList = new List<CourseSeriesModel>();
                if (DBConnection())
                {
                    string userSql = @"select a.course_id,a.course_name,pf.platform_name,
pr.play_count,pr.is_growing,pr.growing_rate
from courses a
left join play_record pr on pr.course_id = a.course_id
left join platforms pf on pf.platform_id = pr.platform_id
order by a.course_id,pf.platform_id";
                    adapter = new SqlDataAdapter(userSql, conn);
                    DataTable dt = new DataTable();
                    int count = adapter.Fill(dt);

                    string courseId = "";
                    CourseSeriesModel cModel = null;
                    foreach (DataRow dr in dt.AsEnumerable())
                    {
                        string tempId = dr.Field<string>("course_id");
                        if (courseId != tempId)
                        {
                            courseId = tempId;
                            cModel = new CourseSeriesModel();
                            cModelList.Add(cModel);

                            cModel.CourseName = dr.Field<string>("course_name");
                            cModel.SeriesCollection = new LiveCharts.SeriesCollection();
                            cModel.SeriesList = new System.Collections.ObjectModel.ObservableCollection<SeriesModel>();
                        }
                        if (cModel != null)
                        {
                            cModel.SeriesCollection.Add(new PieSeries
                            {
                                Title = dr.Field<string>("platform_name"),
                                Values = new ChartValues<ObservableValue> { new ObservableValue((double)dr.Field<decimal>("play_count")) },
                                DataLabels = false
                            });

                            cModel.SeriesList.Add(new SeriesModel
                            {
                                SeriesName= dr.Field<string>("platform_name"),
                                CurrentValue = dr.Field<decimal>("play_count"),
                                IsGrowing = dr.Field<Int32>("is_growing")==1,
                                ChangeRate = (int)dr.Field<decimal>("growing_rate")
                            });
                        }
                    }
                }
                return cModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
        }

        public List<string> GetTeachers()
        {
            try
            {
                List<string> result = new List<string>();
                if (DBConnection())
                {
                    string userSql = "select real_name from users where is_teacher = 1";
                    adapter = new SqlDataAdapter(userSql, conn);
                    DataTable dt = new DataTable();
                    int count = adapter.Fill(dt);

                    if (count > 0)
                    {
                        result = dt.AsEnumerable().Select(x=>x.Field<string>("real_name")).ToList();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
        }

        public List<CourseModel> GetCourses()
        {
            try
            {
                List<CourseModel> result = new List<CourseModel>();
                if (DBConnection())
                {
                    string userSql = @"select c.course_id,c.course_name,c.course_cover,c.description,c.course_url,u.real_name
from courses c
left join course_teacher_relation ctr on ctr.course_id = c.course_id
left join users u on u.user_id = ctr.teacher_id
order by c.course_id,u.user_id";
                    adapter = new SqlDataAdapter(userSql, conn);
                    DataTable dt = new DataTable();
                    int count = adapter.Fill(dt);
                    if (count > 0)
                    {
                        string courseId = "";
                        CourseModel cModel = null;
                        foreach (DataRow dr in dt.AsEnumerable())
                        {
                            string tempId = dr.Field<string>("course_id");
                            if (courseId != tempId)
                            {
                                courseId = tempId;
                                cModel = new CourseModel();
                                cModel.CourseName = dr.Field<string>("course_name");
                                cModel.CourseCover = dr.Field<string>("course_cover");
                                cModel.CourseDescription = dr.Field<string>("description");
                                cModel.CourseUrl = dr.Field<string>("course_url");
                                cModel.Teachers = new List<string>();
                                result.Add(cModel);
                            }
                            if (cModel != null)
                            {
                                cModel.Teachers.Add(dr.Field<string>("real_name"));
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
        }
    }
}
