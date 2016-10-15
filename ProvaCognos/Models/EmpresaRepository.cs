using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProvaCognos.Utils;

namespace ProvaCognos.Models
{
    public class EmpresaRepository
    {
        private static ProvaCognosEntities contextDB = new ProvaCognosEntities();

        public static List<Empresa> list()
        {
            try
            {
                return contextDB.Empresa.Where(x => x.Status != StaticValues.EmpresaStatus.EXCLUIDA).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Empresa get(int empresaID)
        {
            try
            {
                return contextDB.Empresa.Find(empresaID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void save(Empresa empresa)
        {
            try
            {
                contextDB.Empresa.Add(empresa);
                contextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void edit(Empresa empresa)
        {
            try
            {
                Empresa oldEmpresa = contextDB.Empresa.Find(empresa.EmpresaID);
                oldEmpresa.Nome = empresa.Nome;
                oldEmpresa.Telefone = empresa.Telefone;
                oldEmpresa.Site = empresa.Site;
                oldEmpresa.Status = empresa.Status;
                oldEmpresa.DataAlteracao = DateTime.Now;
                oldEmpresa.Contato = empresa.Contato;

                contextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int empresaID)
        {
            try
            {
                Empresa delEmpresa = contextDB.Empresa.Find(empresaID);
                delEmpresa.Status = StaticValues.EmpresaStatus.EXCLUIDA;
                contextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}