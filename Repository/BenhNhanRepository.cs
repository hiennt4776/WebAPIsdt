using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebAPIsdt.Models;

namespace WebAPIsdt.Repository
{
    public class BenhNhanRepository
    {
        private readonly string _connectionString;

        public BenhNhanRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["HospitaldbConnection"].ConnectionString;
        }

        public IEnumerable<BenhNhan> GetAll()
        {
            List<BenhNhan> BenhNhanList = new List<BenhNhan>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "Select MaYTe, TenBenhNhan, NamSinh, GioiTinh, SoDienThoai, DiaChiChiTiet from K_BenhNhan";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BenhNhan benhNhan = new BenhNhan();
                            benhNhan.MaYTe = reader["MaYTe"].ToString();
                            benhNhan.TenBenhNhan = reader["TenBenhNhan"].ToString();
                            benhNhan.NamSinh = reader["NamSinh"] == DBNull.Value ? null : (int?)reader["NamSinh"];
                            benhNhan.GioiTinh = reader["GioiTinh"].ToString();
                            benhNhan.SoDienThoai = reader["SoDienThoai"].ToString();
                            benhNhan.DiaChiChiTiet = reader["DiaChiChiTiet"].ToString();


                            BenhNhanList.Add(benhNhan);
                        }
                    }
                }
            }

            return BenhNhanList;
        }

        public List<BenhNhan> GetBenhNhanTheoSDT(string soDienThoai)
        {
            List<BenhNhan> BenhNhanList = new List<BenhNhan>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
   

                using (SqlCommand command = new SqlCommand("layBenhNhanTheoSDT", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SoDienThoai", SqlDbType.VarChar).Value = soDienThoai;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BenhNhan benhNhan = new BenhNhan();
                            benhNhan.MaYTe = reader["MaYTe"].ToString();
                            benhNhan.TenBenhNhan = reader["TenBenhNhan"].ToString();
                            benhNhan.NamSinh = reader["NamSinh"] == DBNull.Value ? null : (int?)reader["NamSinh"];
                            benhNhan.GioiTinh = reader["GioiTinh"].ToString();
                            benhNhan.SoDienThoai = reader["SoDienThoai"].ToString();
                            benhNhan.DiaChiChiTiet = reader["DiaChiChiTiet"].ToString();
                            benhNhan.ThoiGianTiepNhan = reader["ThoiGianTiepNhan"].ToString();


                            BenhNhanList.Add(benhNhan);
                        }
                    }
                }
            }

            return BenhNhanList;
        }

    }
}