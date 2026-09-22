using System;
using System.Data;
using System.Data.SqlClient;

public class XULYDULIEU
{
    SqlConnection con;

    public XULYDULIEU()
    {
        con = new SqlConnection();
        con.ConnectionString = @"Data Source=DESKTOP-G1G4KDD\MSSQLSERVER02;Initial Catalog=dbQUANLYBANHANG;Integrated Security=True;TrustServerCertificate=True";
    }

    private void MoKetNoi()
    {
        if (con.State == ConnectionState.Closed) con.Open();
    }

    private void DongKetNoi()
    {
        if (con.State == ConnectionState.Open) con.Close();
    }

    public DataTable getTable(String SQL)
    {
        DataTable tb = null;
        try
        {
            this.MoKetNoi();
            SqlDataAdapter adp = new SqlDataAdapter(SQL, con);
            tb = new DataTable();
            adp.Fill(tb);
        }
        catch (Exception ex) { }
        finally { this.DongKetNoi(); }
        return tb;
    }

    public DataTable getTable(String nameprocedurce, SqlParameter[] pr)
    {
        DataTable tb = null;
        try
        {
            this.MoKetNoi();
            tb = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nameprocedurce;
            if (pr != null) cmd.Parameters.AddRange(pr);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(tb);
        }
        catch (Exception ex) { }
        finally { this.DongKetNoi(); }
        return tb;
    }

    public int ExeCute(string SQL)
    {
        int k = 0;
        try
        {
            this.MoKetNoi();
            SqlCommand cmd = new SqlCommand(SQL, this.con);
            k = (int)cmd.ExecuteNonQuery();
        }
        catch (Exception ex) { }
        finally { this.DongKetNoi(); }
        return k;
    }

    public int ExeCute(String nameprocedurce, SqlParameter[] pr)
    {
        int k = 0;
        try
        {
            this.MoKetNoi();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nameprocedurce;
            if (pr != null) cmd.Parameters.AddRange(pr);
            k = (int)cmd.ExecuteNonQuery();
        }
        catch (Exception ex) { }
        finally { this.DongKetNoi(); }
        return k;
    }
}