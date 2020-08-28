﻿using System;
using System.Data;
using Arqueng.DAO;
using Arqueng.ENTIDADES;

namespace Arqueng.MODEL
{


    public class OsMODEL
    {


        OsDAO dao = new OsDAO();


        public DataTable ListarOsModel()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.SelectAllDAO();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void InsertOsModel(OsENT dado)
        {
            try
            {
                dao.InsertDAO(dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateOsModel(OsENT dado)
        {
            try
            {
                dao.UpdateDAO(dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UpdateOsFaturadaModel(OsENT dado)
        {
            try
            {
                dao.UpdateFaturada(dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable ListarOSFaturaModel()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.ListarOSFaturaDAO();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




























        public DataTable ListarOSAFaturarModel()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.ListarOSAFaturarDAO();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public DataTable DistinctProOSFaturadaModel(OsENT dado)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dao.DistinctProOSFaturadaDAO(dado);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        


        



        public void UpdateStatusModel(OsENT dado)
        {
            if (dado.Status == "RECEBIDA")
            {
                try
                {
                    dao.UpdateStatusRecebida(dado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (dado.Status == "PENDENTE")
            {
                try
                {
                    dao.UpdateStatusPendente(dado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (dado.Status == "VISTORIADA")
            {
                try
                {
                    dao.UpdateStatusVistoriada(dado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    dao.UpdateStatusConcluida(dado);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        public void DeleteOsModel(OsENT dado)
        {
            try
            {
                dao.DeleteOsDAO(dado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }


}
