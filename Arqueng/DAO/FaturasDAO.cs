﻿using System;
using System.Data;
using MySql.Data.MySqlClient;
using Fluxus.ENTIDADES;

namespace Fluxus.DAO
{


    class FaturasDAO
    {
        MySqlCommand sql;
        CONEXAO con = new CONEXAO();




        //:INSERT
        public void Insert(FaturasENT dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("INSERT INTO tb_fatura(descricao, data, subtotal_os, subtotal_desloc, total) VALUES (@descricao, @data, @subtotal_os, @subtotal_desloc, @total)", con.con);
                sql.Parameters.AddWithValue("@descricao", dado.descricao);
                sql.Parameters.AddWithValue("@data", dado.data);
                sql.Parameters.AddWithValue("@subtotal_os", dado.subtotal_os);
                sql.Parameters.AddWithValue("@subtotal_desloc", dado.subtotal_desloc);
                sql.Parameters.AddWithValue("@total", dado.total);
                sql.ExecuteNonQuery();

                dado.id = Convert.ToInt32(sql.LastInsertedId);

                con.FecharConexao();
            }
            catch (Exception)
            {
                con.FecharConexao();
                throw;
            }
        }



        //:UPDATE
        public void UpdateValores(FaturasENT dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("UPDATE tb_fatura SET subtotal_os = @subtotal_os, subtotal_desloc = @subtotal_desloc, total = @total WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@id", dado.id);
                sql.Parameters.AddWithValue("@descricao", dado.descricao);
                sql.Parameters.AddWithValue("@subtotal_os", dado.subtotal_os);
                sql.Parameters.AddWithValue("@subtotal_desloc", dado.subtotal_desloc);
                sql.Parameters.AddWithValue("@total", dado.total);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception)
            {
                con.FecharConexao();
                throw;
            }
        }



        //:DELETE
        public void Delete(FaturasENT dado)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("DELETE FROM tb_fatura WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@id", dado.id);
                sql.ExecuteNonQuery();
                con.FecharConexao();
            }
            catch (Exception)
            {
                con.FecharConexao();
                throw;
            }
        }



        //:SELECT
        public DataTable SelectAll()
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT * FROM tb_fatura ORDER BY data", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string SelectDescricaoDaFatura(string id)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT descricao FROM tb_fatura WHERE id = @id", con.con);
                sql.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = sql.ExecuteReader();
                dr.Read();
                if (dr.HasRows == false)
                    return null;
                else
                    return Convert.ToString(dr["descricao"]);
            }
            catch (Exception)
            {
                throw;
            }
        }


        
    }


}
