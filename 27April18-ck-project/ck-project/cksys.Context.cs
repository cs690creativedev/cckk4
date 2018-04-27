﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ck_project
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class ckdatabase : DbContext
{
    public ckdatabase()
        : base("name=ckdatabase")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<rates_installation> rates_installation { get; set; }

    public virtual DbSet<taxes_leads> taxes_leads { get; set; }

    public virtual DbSet<address> addresses { get; set; }

    public virtual DbSet<branch> branches { get; set; }

    public virtual DbSet<building_permit> building_permit { get; set; }

    public virtual DbSet<customer> customers { get; set; }

    public virtual DbSet<delivery_status> delivery_status { get; set; }

    public virtual DbSet<employee> employees { get; set; }

    public virtual DbSet<installation> installations { get; set; }

    public virtual DbSet<lead_log_file> lead_log_file { get; set; }

    public virtual DbSet<lead_source> lead_source { get; set; }

    public virtual DbSet<lead> leads { get; set; }

    public virtual DbSet<product> products { get; set; }

    public virtual DbSet<project_class> project_class { get; set; }

    public virtual DbSet<project_status> project_status { get; set; }

    public virtual DbSet<project_type> project_type { get; set; }

    public virtual DbSet<rate> rates { get; set; }

    public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

    public virtual DbSet<task> tasks { get; set; }

    public virtual DbSet<tasks_installation> tasks_installation { get; set; }

    public virtual DbSet<tax> taxes { get; set; }

    public virtual DbSet<total_cost> total_cost { get; set; }

    public virtual DbSet<users_types> users_types { get; set; }

    public virtual DbSet<archive_leads> archive_leads { get; set; }

    public virtual DbSet<lead_source_report> lead_source_report { get; set; }

    public virtual int LoginByUsernamePassword(string username, string password)
    {

        var usernameParameter = username != null ?
            new ObjectParameter("username", username) :
            new ObjectParameter("username", typeof(string));


        var passwordParameter = password != null ?
            new ObjectParameter("password", password) :
            new ObjectParameter("password", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LoginByUsernamePassword", usernameParameter, passwordParameter);
    }


    [DbFunction("ckdatabase", "fn_view3")]
    public virtual IQueryable<fn_view3_Result> fn_view3(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view3_Result>("[ckdatabase].[fn_view3](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view2")]
    public virtual IQueryable<fn_view2_Result> fn_view2(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view2_Result>("[ckdatabase].[fn_view2](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view4")]
    public virtual IQueryable<fn_view4_Result> fn_view4(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view4_Result>("[ckdatabase].[fn_view4](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view5_1")]
    public virtual IQueryable<fn_view5_1_Result> fn_view5_1(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view5_1_Result>("[ckdatabase].[fn_view5_1](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view5_2")]
    public virtual IQueryable<fn_view5_2_Result> fn_view5_2(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view5_2_Result>("[ckdatabase].[fn_view5_2](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view6")]
    public virtual IQueryable<fn_view6_Result> fn_view6(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view6_Result>("[ckdatabase].[fn_view6](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view10")]
    public virtual IQueryable<fn_view10_Result> fn_view10(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view10_Result>("[ckdatabase].[fn_view10](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view7")]
    public virtual IQueryable<fn_view7_Result> fn_view7(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view7_Result>("[ckdatabase].[fn_view7](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view8")]
    public virtual IQueryable<fn_view8_Result> fn_view8(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view8_Result>("[ckdatabase].[fn_view8](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view9")]
    public virtual IQueryable<fn_view9_Result> fn_view9(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view9_Result>("[ckdatabase].[fn_view9](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view13")]
    public virtual IQueryable<fn_view13_Result> fn_view13(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view13_Result>("[ckdatabase].[fn_view13](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view14")]
    public virtual IQueryable<fn_view14_Result> fn_view14(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view14_Result>("[ckdatabase].[fn_view14](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view15")]
    public virtual IQueryable<fn_view15_Result> fn_view15(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view15_Result>("[ckdatabase].[fn_view15](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }


    [DbFunction("ckdatabase", "fn_view16")]
    public virtual IQueryable<fn_view16_Result> fn_view16(Nullable<System.DateTime> dtFrom, Nullable<System.DateTime> dtTo)
    {

        var dtFromParameter = dtFrom.HasValue ?
            new ObjectParameter("dtFrom", dtFrom) :
            new ObjectParameter("dtFrom", typeof(System.DateTime));


        var dtToParameter = dtTo.HasValue ?
            new ObjectParameter("dtTo", dtTo) :
            new ObjectParameter("dtTo", typeof(System.DateTime));


        return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_view16_Result>("[ckdatabase].[fn_view16](@dtFrom, @dtTo)", dtFromParameter, dtToParameter);
    }

        public int SaveChanges(int lead_id, string op = "update")
        {
            var changes = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
            var time_s = DateTime.Now.ToLocalTime();
            foreach (var change in changes)
            {
                var target_name = change.Entity.GetType().Name;


                foreach (var field in change.OriginalValues.PropertyNames)
                {
                    if (change.OriginalValues[field] == null || change.CurrentValues[field] == null) continue;
                    if (change.OriginalValues[field].ToString() != change.CurrentValues[field].ToString())
                    {
                        lead_log_file log = new lead_log_file
                        {
                            prvious_value = change.OriginalValues[field].ToString(),
                            new_value = change.CurrentValues[field].ToString(),
                            table_name = change.Entity.GetType().Name.Split('_')[0],
                            column_name = field,
                            update_date = time_s,
                            lead_number = lead_id,
                            emp_username = System.Web.HttpContext.Current.User.Identity.Name,
                            action_name = op
                        };
                        this.lead_log_file.Add(log);
                    }
                }
            }
            return base.SaveChanges();
        }
    }

}

