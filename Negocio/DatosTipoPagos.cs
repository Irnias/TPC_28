﻿using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class DatosTipoPagos
    {
        public List<TipoPagos> Listar()
        {
            List<TipoPagos> l = new List<TipoPagos>();
            AccesoDatos db = new AccesoDatos();

            try
            {
                db.setQuery("Select IdTipoPago AS Id, Descripcion as Descripcion FROM TipoPagos");
                db.ejecutar();

                while (db.sqlLector.Read())
                {
                    TipoPagos t = new TipoPagos();
                    t.Id = (int)db.sqlLector["Id"];
                    t.Descripcion = (string)db.sqlLector["Descripcion"];

                    l.Add(t);
                }

                return l;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Cerrar();
            }
        }

        public void NuevoTipoDePago(string Nombre)
        {
            AccesoDatos db = new AccesoDatos();
            try
            {
                if (Nombre.Length > 0)
                {
                    db.setQuery("INSERT INTO TipoPagos (Descripcion) values (@nombre)");
                    db.setearParametro("@nombre", Nombre);
                    db.ejecutar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Cerrar();
            }
        }

        public void BorradoLogicoPorId(int id)
        {
            AccesoDatos db = new AccesoDatos();
            //TODO agregar columna de borrado logico
            try
            {
                if (id > 0)
                {
                    db.setQuery("DELETE TipoPagos WHERE IdTipoPago = @id");
                    db.setearParametro("@id", id);
                    db.ejecutar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                db.Cerrar();
            }
        }
    }
}
