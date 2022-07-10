using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WebSubjectManagement.Models
{
    public class MonHoc
    {
        
        [Required(ErrorMessage = "Fill Infor please")]
        [Display(Name = "TEN Ma mon HOC:")]
        public int MaMH { get; set; }
        [Required(ErrorMessage = "Fill Inform please")]
        [Display(Name = "TenMH")]
        public string TenMH { get; set; }
        [Required(ErrorMessage = "Fill Inform please")]
        [Display(Name = "TCLT")]
        public int TCLT { get; set; }
        [Required(ErrorMessage = "Fill Inform please")]
        [Display(Name = "TCLH")]
        public int TCTH { get; set; }

        [Required(ErrorMessage = "Fill Inform please")]
        [Display(Name = "MaKhoa")]
        public string MaKhoa { get; set; }
      
    }
    public class ListMonHoc
        {
        DBConnection dBConnection;
        public ListMonHoc()
        {
            dBConnection = new DBConnection();
        }
        public List<MonHoc>getds(string MaMH)
        {
            string url;
            if(string.IsNullOrEmpty(MaMH))
            {
                url = "SELECT *FROM MONHOC";
            }
            else
            {
                url = "SELECT *FROM MONHOC WHERE MAMH=" + MaMH;
            }
            List<MonHoc> dsmonhoc = new List<MonHoc>();
            DataTable dt = new DataTable();
            SqlConnection conn = dBConnection.getConn();
            SqlDataAdapter da = new SqlDataAdapter(url, conn);
            conn.Open();
            da.Fill(dt);
            da.Dispose();
            conn.Close();
            MonHoc temp;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                temp = new MonHoc();
                temp.MaMH = Convert.ToInt32(dt.Rows[i]["MaMH"].ToString());
                temp.TenMH = dt.Rows[i]["TenMH"].ToString();
                temp.TCLT = Convert.ToInt32(dt.Rows[i]["TCLT"].ToString());
                temp.TCTH = Convert.ToInt32(dt.Rows[i]["TCTH"].ToString());
                temp.MaKhoa = dt.Rows[i]["MAKHOA"].ToString();
                dsmonhoc.Add(temp);
            }
            return dsmonhoc;
        }
        public void InsertMH(MonHoc mh)
        {
            string url = 
             "Insert into MONHOC Values('" + mh.MaMH + "','" + mh.TenMH + "','" + mh.TCLT + "','" + mh.TCTH + "','" + mh.MaKhoa + "')";
            SqlConnection conn = dBConnection.getConn();
            SqlCommand cmd = new SqlCommand(url,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();


        }
        public void EditMH(MonHoc mh)
        {
            string url = "UPDATE MONHOC SET TenMH='"+mh.TenMH+"',TCLT='"+mh.TCLT+"',TCTH='"+mh.TCTH+"',MaKhoa='"+mh.MaKhoa+"' where MaMH="+mh.MaMH;
            SqlConnection conn = dBConnection.getConn();
            SqlCommand cmd = new SqlCommand(url, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        public void DeleteMH(MonHoc mh)
        {
            string url = "DELETE FROM MONHOC where MaMH="+mh.MaMH; 
            SqlConnection conn = dBConnection.getConn();
            SqlCommand cmd = new SqlCommand(url, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

        }

        }
}