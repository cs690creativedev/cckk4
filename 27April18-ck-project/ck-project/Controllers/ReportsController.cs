using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using ck_project.Models;
using System.Data;
using System.Dynamic;

namespace ck_project.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        ckdatabase db = new ckdatabase();
        
        public ActionResult CompanyLeadSourceAnalysis(int? page, string search  ,string search1  )
        {
            string query;
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            //DataTable dt = new DataTable();

            query = "ALTER view [dbo].[reported] as select lead_source.source_name,branch_name,count(leads.branch_number) Branch_Count from leads,branches,lead_source where leads.branch_number=branches.branch_number and leads.source_number=lead_source.source_number";
            if (search != null && search1 != null)
            {
                query = query + " and lead_date>='" + search + "' and lead_date<='" + search1 + "'";
            }
            else
            {
                query = query + " and lead_date>='" + "01-01-1900" + "' and lead_date<='" + "01-01-1900" + "'";
            }

            query = query + " group by lead_source.source_name,branch_name";

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            
            var ctx1 = new ckdatabase();
            int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);

           
            return View(db.lead_source_report.Where(x=> x.total>0).ToList().ToPagedList(page ?? 1, 100));
        }
        public ActionResult CompanyProjectTypeAnalysis(int? page, string search, string search1)
        {
            //string query="";
            //string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            //SqlConnection con = new SqlConnection(constr);
            //if (search != null && search1 != null)
            //{

            //    query = " select * from dbo.fn_view2('" + search + "','" + search1 + "')";

            //    var ctx = new ckdatabase();
            //    int noOfRowUpdated = ctx.Database.ExecuteSqlCommand(query);
            //}
            //else
            //{

            //    query = " select * from dbo.fn_view2('" + "01-01-1900" + "','" + "01-01-1900" + "')";
            //    var ctx = new ckdatabase();
            //    int noOfRowUpdated = ctx.Database.ExecuteSqlCommand(query);
            //}
            //Session["dtFrom"] = search;
            //Session["dtTo"] = search1;
            //if (search != "" && search != null)
            //{
            //    DateTime From = Convert.ToDateTime(search);
            //    DateTime To = Convert.ToDateTime(search1);
            //    return View(db.fn_view2(From, To).Where(x => x.Total > 0).ToList().ToPagedList(page ?? 1, 100));
            //}
            //else
            //{
            //    DateTime From = Convert.ToDateTime("01-01-1900");
            //    DateTime To = Convert.ToDateTime("01-01-1900");
            //    return View(db.fn_view2(From, To).Where(x => x.Total > 0).ToList().ToPagedList(page ?? 1, 100));
            //}

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            dynamic model = new ExpandoObject();
            model.CLSA2 = GetCLSA2();
            return View(model);

        }
        public List<CLSA2> GetCLSA2()
        {
            string query = "";
            DateTime dtFrom;
            DateTime dtTo;
            List<CLSA2> Data = new List<CLSA2>();
            if (Session["dtFrom"] != null && Session["dtFrom"].ToString() != "" && Session["dtTo"] != null && Session["dtTo"].ToString() != "")
            {
                dtTo = Convert.ToDateTime(Session["dtTo"].ToString());
                dtFrom = Convert.ToDateTime(Session["dtFrom"].ToString());
                query = "select * from dbo.fn_view2('" + dtFrom + "','" + dtTo + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows == true)
                                {
                                while (sdr.Read())
                                {
                                    if (sdr["Huntington"] != System.DBNull.Value)
                                    {
                                        Data.Add(new CLSA2
                                        {
                                            ProjectName = sdr["Project Type Name"].ToString(),
                                            Huntington = (Int32)sdr["Huntington"],
                                            Charleston = (Int32)sdr["Charleston"],
                                            Lewisburg = (Int32)sdr["Lewisburg"],
                                            total = (Int32)sdr["Total"]

                                        });
                                    }
                                }
                            }
                        }
                        con.Close();

                    }

                }
               
            }
            return Data;
        }

        public ActionResult CompanyLeadStatusAnalysis(int? page, string search, string search1)
        {
            string query="";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

             if (search != null && search1 != null)
            {
                
                query = " select * from dbo.fn_view3('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {
                
                query = " select * from dbo.fn_view3('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
           
            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {
                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view3(From, To).Where(x => x.Total > 0).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view3(From, To).Where(x => x.Total > 0).ToList().ToPagedList(page ?? 1, 100));
            }
        }
        public ActionResult CompanyProductTypeAnalysis(int? page, string search, string search1)
        {
            string query = "";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if (search != null && search1 != null)
            {

                query = " select * from dbo.fn_view4('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {

                query = " select * from dbo.fn_view4('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {
                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view4(From, To).Where(x => x.Company_Total > 0).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view4(From, To).Where(x => x.Company_Total > 0).ToList().ToPagedList(page ?? 1, 100));
            }
        }

        public ActionResult CompanyLeadTypeCategoryAnalysis(int? page, string search, string search1)
        {
            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            dynamic model = new ExpandoObject();
            model.CLSA5_1S = GetCLSA5_1();
            
            return View(model);
        }

        public List<CLSA5_1> GetCLSA5_1()
        {
            string query = "";
            List<CLSA5_1> ProjectType = new List<CLSA5_1>();
            if (Session["dtFrom"] != null && Session["dtTo"] != null && Session["dtFrom"].ToString() != "" && Session["dtTo"].ToString() != "")
            {

                query = "select * from dbo.fn_view5_1('" + Session["dtFrom"] + "','" + Session["dtTo"] + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Huntington"] != System.DBNull.Value)
                                { 
                                    ProjectType.Add(new CLSA5_1
                                    {
                                        Project_Type = sdr["Project Type"].ToString(),
                                        Huntington = (int)sdr["Huntington"],
                                        Charleston = (int)sdr["Charleston"],
                                        Lewisburg = (int)sdr["Lewisburg"],
                                        Total = (int)sdr["Total"]
                                    });
                                }
                            }
                        }
                        con.Close();

                    }
                }
            }
            if (Session["dtFrom"] != null && Session["dtTo"] != null && Session["dtFrom"].ToString() != "" && Session["dtTo"].ToString() != "")
            {
                query = "select * from dbo.fn_view5_2('" + Session["dtFrom"] + "','" + Session["dtTo"] + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Huntington"] != System.DBNull.Value)
                                {
                                    ProjectType.Add(new CLSA5_1
                                    {
                                        Delivery_Type = sdr["Delivery Type"].ToString(),
                                        Huntington2 = (int)sdr["Huntington"],
                                        Charleston2 = (int)sdr["Charleston"],
                                        Lewisburg2 = (int)sdr["Lewisburg"],
                                        Total2 = (int)sdr["Total"]
                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
            }

            else
            {
                query = "select * from dbo.fn_view5_1('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Huntington"]!=System.DBNull.Value)
                                {
                                    ProjectType.Add(new CLSA5_1
                                    {
                                        Project_Type = sdr["Project Type"].ToString(),
                                        Huntington = (int)sdr["Huntington"],
                                        Charleston = (int)sdr["Charleston"],
                                        Lewisburg = (int)sdr["Lewisburg"],
                                        Total = (int)sdr["Total"]
                                    });
                                }
                            }
                        }
                        con.Close();

                    }
                }
                query = "select * from dbo.fn_view5_2('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Huntington"] != System.DBNull.Value)
                                { 
                                    ProjectType.Add(new CLSA5_1
                                {
                                    Delivery_Type = sdr["Delivery Type"].ToString(),
                                    Huntington2 = (int)sdr["Huntington"],
                                    Charleston2 = (int)sdr["Charleston"],
                                    Lewisburg2 = (int)sdr["Lewisburg"],
                                    Total2 = (int)sdr["Total"]
                                });
                                }
                            }
                            con.Close();

                        }
                    }
                }
            }
            return ProjectType;
        }

        public List<CLSA5_2> GetCLSA5_2()
        {
            string query = "";
            List<CLSA5_2> DeliveyType = new List<CLSA5_2>();
            if (Session["dtFrom"] != null && Session["dtTo"] != null && Session["dtFrom"].ToString() != "" && Session["dtTo"].ToString() != "")
            {
                query = "select * from dbo.fn_view5_2('" + Session["dtFrom"] + "','" + Session["dtTo"] + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DeliveyType.Add(new CLSA5_2
                                {
                                    Delivery_Type = sdr["Delivery Type"].ToString(),
                                    Huntington = (int)sdr["Huntington"],
                                    Charleston = (int)sdr["Charleston"],
                                    Lewisburg = (int)sdr["Lewisburg"],
                                    Total = (int)sdr["Total"]
                                });
                            }
                            con.Close();

                        }
                    }
                }
            }
            else
            {
                query = "select * from dbo.fn_view5_2('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                DeliveyType.Add(new CLSA5_2
                                {
                                    Delivery_Type = sdr["Delivery Type"].ToString(),
                                    Huntington = (int)sdr["Huntington"],
                                    Charleston = (int)sdr["Charleston"],
                                    Lewisburg = (int)sdr["Lewisburg"],
                                    Total = (int)sdr["Total"]
                                });
                            }
                            con.Close();

                        }
                    }
                }
            }
            return DeliveyType;
        }

        public ActionResult CompanyDesignerLeadStatusTotals(int? page, string search, string search1)
        {
            string query = "";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if (search != null && search1 != null)
            {

                query = " select * from dbo.fn_view6('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {

                query = " select * from dbo.fn_view6('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {
                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view6(From, To).Where(x => x.Total > 0).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view6(From, To).Where(x => x.Total > 0).ToList().ToPagedList(page ?? 1, 100));
            }
        }

        public ActionResult CompanyDesignerLeadStatus(int? page, string search, string search1)
        {
            string query = "";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if (search != null && search1 != null)
            {

                query = " select * from dbo.fn_view7('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {

                query = " select * from dbo.fn_view7('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {
                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view7(From, To).Where(x => x.Total > 0).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view7(From, To).Where(x => x.Total > 0).ToList().ToPagedList(page ?? 1, 100));
            }
        }

        public ActionResult CompanySoldAndClosedJobs(int? page, string search, string search1)
        {
            string query = "";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if (search != null && search1 != null)
            {

                query = " select * from dbo.fn_view8('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {

                query = " select * from dbo.fn_view8('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {
                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view8(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view8(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
        }

        public ActionResult CompanySoldJobsOnly(int? page, string search, string search1)
        {
            string query = "";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if (search != null && search1 != null)
            {

                query = " select * from dbo.fn_view9('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {

                query = " select * from dbo.fn_view9('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {
                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view9(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view9(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
        }

        public ActionResult DesignerActiveLeadReport(int? page, string search, string search1)
        {
            string query = "";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if (search != null && search1 != null)
            {

                query = " select * from dbo.fn_view10('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {

                query = " select * from dbo.fn_view10('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {

                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view10(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view10(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
        }

        public ActionResult DesignerYearToDateReport(int? page, string search, string search1)
        {
            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            dynamic model = new ExpandoObject();
            model.CLSA11 = GetCLSA11();
            return View(model);
        }

        public List<CLSA11> GetCLSA11()
        {
            string query = "";
            DateTime dtFrom;
            DateTime dtTo;

            List<CLSA11> Data = new List<CLSA11>();
            if (Session["dtTo"] != null  && Session["dtTo"].ToString() != "")
            {
                dtTo = Convert.ToDateTime(Session["dtTo"].ToString()) ;
                dtFrom = new DateTime(dtTo.Year, 1, 1);
                Session["dtFrom"] = dtFrom.ToString() ;

                query = "select * from dbo.fn_view11_1('" + dtFrom + "','" + Session["dtTo"] + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["QTY"] != System.DBNull.Value)
                                { 
                                Data.Add(new CLSA11
                                {
                                    Type = sdr["Type"].ToString(),
                                    QTY = (int)sdr["QTY"],
                                    Total_Amount = (double)sdr["Total Amount"],
                                    Total1 = 1,

                                });
                                }
                            }
                        }
                        con.Close();

                    }
                }

                query = "select * from dbo.fn_view11_2('" + dtFrom + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["QTY"] != System.DBNull.Value)
                                { 
                                        Data.Add(new CLSA11
                                    {
                                        Type2 = sdr["Type"].ToString(),
                                        QTY2 = (int)sdr["QTY"],
                                        Total_Amount2 = (double)sdr["Total Amount"],
                                        Total2 = 2,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view11_3('" + dtFrom + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["QTY"] != System.DBNull.Value)
                                { 
                                    Data.Add(new CLSA11
                                {
                                    Status = sdr["Status"].ToString(),
                                    QTY3 = (int)sdr["QTY"],
                                    Total3 = 3,

                                });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view11_4('" + dtFrom + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Numerics"] != System.DBNull.Value)
                                { 
                                    Data.Add(new CLSA11
                                {
                                    YTD_Statistics = sdr["YTD Statistics"].ToString(),
                                    Numerics = (double)sdr["Numerics"],
                                    Total4 = 4,

                                });
                                }
                            }
                            con.Close();

                        }
                    }
                }
            }

           
           
            return Data;
        }

        public ActionResult LocationStatisticsOfSoldJobs(int? page, string search, string search1)
        {
            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            dynamic model = new ExpandoObject();
            model.CLSA12 = GetCLSA12();
            return View(model);
        }

        public List<CLSA12> GetCLSA12()
        {
            string query = "";
            List<CLSA12> Data = new List<CLSA12>();
            if (Session["dtFrom"] != null && Session["dtTo"] != null && Session["dtFrom"].ToString() != "" && Session["dtTo"].ToString() != "")
            {

                query = "select * from dbo.fn_view12_1('" + Session["dtFrom"] + "','" + Session["dtTo"] + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["No. of Leads"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        State = sdr["State"].ToString(),
                                        No_of_Leads = (int)sdr["No. of Leads"],
                                        No_of_Leads_Sold = (int)sdr["No. of Leads Sold"],
                                        Total_amount_of_Sold_Jobs = (double)sdr["Total amount of Sold Jobs"],
                                        Total1 = 1,

                                    });
                                }
                            }
                        }
                        con.Close();

                    }
                }

                query = "select * from dbo.fn_view12_2('" + Session["dtFrom"] + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["QTY"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        QTY = (int)sdr["QTY"],
                                        City = sdr["City"].ToString(),
                                        Total2 = 2,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view12_3('" + Session["dtFrom"] + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["QTY"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        QTY3 = (int)sdr["QTY"],
                                        City3 = sdr["City"].ToString(),
                                        Total3 = 3,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view12_4('" + Session["dtFrom"] + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["QTY"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        QTY4 = (int)sdr["QTY"],
                                        City4 = sdr["City"].ToString(),
                                        Total4 = 4,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view12_5('" + Session["dtFrom"] + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Installed"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        State5 = sdr["State"].ToString(),
                                        Installed5 = (double)sdr["Installed"],
                                        Pickup5 = (double)sdr["Pickup"],
                                        Delivered5 = (double)sdr["Delivered"],
                                        In_City_Installed5 = (double)sdr["In-City Installed"],
                                        Out_City_Installed5 = (double)sdr["Out-City Installed"],
                                        Remodel5 = (double)sdr["Remodel"],
                                        New_Construction5 = (double)sdr["New Construction"],
                                        Builder5 = (double)sdr["Builder"],
                                        Total5 = 5,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view12_6('" + Session["dtFrom"] + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Installed"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        Total = sdr["Total"].ToString(),
                                        Installed6 = (double)sdr["Installed"],
                                        Pickup6 = (double)sdr["Pickup"],
                                        Delivered6 = (double)sdr["Delivered"],
                                        In_City_Installed6 = (double)sdr["In-City Installed"],
                                        Out_City_Installed6 = (double)sdr["Out-City Installed"],
                                        Remodel6 = (double)sdr["Remodel"],
                                        New_Construction6 = (double)sdr["New Construction"],
                                        Builder6 = (double)sdr["Builder"],
                                        Total6 = 6,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
            }

            else
            {
                query = "select * from dbo.fn_view12_1('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["No. of Leads"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        State = sdr["State"].ToString(),
                                        No_of_Leads = (int)sdr["No. of Leads"],
                                        No_of_Leads_Sold = (int)sdr["No. of Leads Sold"],
                                        Total_amount_of_Sold_Jobs = (double)sdr["Total amount of Sold Jobs"],
                                        Total1 = 1,

                                    });
                                }
                            }
                        }
                        con.Close();

                    }
                }

                query = "select * from dbo.fn_view12_2('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["QTY"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        QTY = (int)sdr["QTY"],
                                        City = sdr["City"].ToString(),
                                        Total2 = 2,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view12_3('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["QTY"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        QTY3 = (int)sdr["QTY"],
                                        City3 = sdr["City"].ToString(),
                                        Total3 = 3,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view12_4('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["QTY"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        QTY4 = (int)sdr["QTY"],
                                        City4 = sdr["City"].ToString(),
                                        Total4 = 4,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view12_5('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Installed"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        State5 = sdr["State"].ToString(),
                                        Installed5 = (double)sdr["Installed"],
                                        Pickup5 = (double)sdr["Pickup"],
                                        Delivered5 = (double)sdr["Delivered"],
                                        In_City_Installed5 = (double)sdr["In-City Installed"],
                                        Out_City_Installed5 = (double)sdr["Out-City Installed"],
                                        Remodel5 = (double)sdr["Remodel"],
                                        New_Construction5 = (double)sdr["New Construction"],
                                        Builder5 = (double)sdr["Builder"],
                                        Total5 = 5,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view12_6('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Installed"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA12
                                    {
                                        Total = sdr["Total"].ToString(),
                                        Installed6 = (double)sdr["Installed"],
                                        Pickup6 = (double)sdr["Pickup"],
                                        Delivered6 = (double)sdr["Delivered"],
                                        In_City_Installed6 = (double)sdr["In-City Installed"],
                                        Out_City_Installed6 = (double)sdr["Out-City Installed"],
                                        Remodel6 = (double)sdr["Remodel"],
                                        New_Construction6 = (double)sdr["New Construction"],
                                        Builder6 = (double)sdr["Builder"],
                                        Total6 = 6,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
            }
                return Data;  
        }

        public ActionResult AccountingSoldJobReport(int? page, string search, string search1)
        {
            string query = "";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if (search != null && search1 != null)
            {

                query = " select * from dbo.fn_view13('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {

                query = " select * from dbo.fn_view13('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {
                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view13(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view13(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
        }

        public ActionResult CompanyYearToDateByDesignerReport(int? page, string search, string search1)
        {
            string query = "";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if (search != null && search1 != null)
            {

                query = " select * from dbo.fn_view14('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {

                query = " select * from dbo.fn_view14('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {
                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view14(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view14(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
        }

        public ActionResult MonthlySalesReport(int? page, string search, string search1)
        {
            string query = "";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if (search != null && search1 != null)
            {

                query = " select * from dbo.fn_view15('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {

                query = " select * from dbo.fn_view15('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {
                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view15(From, To).Where(x => x.Total > 0).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view15(From, To).Where(x => x.Total > 0).ToList().ToPagedList(page ?? 1, 100));
            }
        }

        public ActionResult AllOpenLeads(int? page, string search, string search1)
        {
            string query = "";
            string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if (search != null && search1 != null)
            {

                query = " select * from dbo.fn_view16('" + search + "','" + search1 + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }
            else
            {

                query = " select * from dbo.fn_view16('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                var ctx1 = new ckdatabase();
                int noOfRowUpdated = ctx1.Database.ExecuteSqlCommand(query);
            }

            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            if (search != "" && search != null)
            {
                DateTime From = Convert.ToDateTime(search);
                DateTime To = Convert.ToDateTime(search1);
                return View(db.fn_view16(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
            else
            {
                DateTime From = Convert.ToDateTime("01-01-1900");
                DateTime To = Convert.ToDateTime("01-01-1900");
                return View(db.fn_view16(From, To).ToList().ToPagedList(page ?? 1, 100));
            }
        }

        public ActionResult CompanySalesDashboard(int? page, string search, string search1)
        {
            Session["dtFrom"] = search;
            Session["dtTo"] = search1;
            dynamic model = new ExpandoObject();
            model.CLSA17 = GetCLSA17();
            return View(model);
        }

        public List<CLSA17> GetCLSA17()
        {
            string query = "";
            DateTime dtFrom;
            DateTime dtTo;
            List<CLSA17> Data = new List<CLSA17>();
            if (Session["dtTo"] != null && Session["dtTo"].ToString() != "")
            {
                dtTo = Convert.ToDateTime(Session["dtTo"].ToString());
                dtFrom = new DateTime(dtTo.Year, 1, 1);
                Session["dtFrom"] = dtFrom;
                query = "select * from dbo.fn_view17_1('" + dtFrom + "','" + Session["dtTo"] + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["YTD Total Sales"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA17
                                    {
                                        Branch_Name = sdr["Branch Name"].ToString(),
                                        YTD_Total_Sales = (double)sdr["YTD Total Sales"],
                                        Total1 = 1,

                                    });
                                }
                            }
                        }
                        con.Close();

                    }
                }

                query = "select * from dbo.fn_view17_2('" + dtFrom + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Price"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA17
                                    {
                                        Month = sdr["Month"].ToString(),
                                        Price = (double)sdr["Price"],
                                        Total2 = 2,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view17_3('" + dtFrom + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Price"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA17
                                    {
                                        Month3 = sdr["Month"].ToString(),
                                        Price3 = (double)sdr["Price"],
                                        Total3 = 3,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view17_4('" + dtFrom + "','" + Session["dtTo"] + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())

                            {
                                if (sdr["Price"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA17
                                    {
                                        Month4 = sdr["Month"].ToString(),
                                        Price4 = (double)sdr["Price"],
                                        Total4 = 4,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
            }

            else
            {
                query = "select * from dbo.fn_view17_1('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                string constr = ConfigurationManager.ConnectionStrings["CKConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["YTD Total Sales"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA17
                                    {
                                        Branch_Name = sdr["Branch Name"].ToString(),
                                        YTD_Total_Sales = (double)sdr["YTD Total Sales"],
                                        Total1 = 1,

                                    });
                                }
                            }
                        }
                        con.Close();

                    }
                }

                query = "select * from dbo.fn_view17_2('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Price"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA17
                                    {
                                        Month = sdr["Month"].ToString(),
                                        Price = (double)sdr["Price"],
                                        Total2 = 2,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view17_3('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Price"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA17
                                    {
                                        Month3 = sdr["Month"].ToString(),
                                        Price3 = (double)sdr["Price"],
                                        Total3 = 3,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
                query = "select * from dbo.fn_view17_4('" + "01-01-1900" + "','" + "01-01-1900" + "')";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                if (sdr["Price"] != System.DBNull.Value)
                                {
                                    Data.Add(new CLSA17
                                    {
                                        Month4 = sdr["Month"].ToString(),
                                        Price4 = (double)sdr["Price"],
                                        Total4 = 4,

                                    });
                                }
                            }
                            con.Close();

                        }
                    }
                }
            }
            return Data;
        }
    }
}