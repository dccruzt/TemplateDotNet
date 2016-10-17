using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProvaCognos.Utils;

namespace ProvaCognos.Models
{
    public class ContatoRepository
    {
        private static ProvaCognosEntities contextDB = new ProvaCognosEntities();

        public static List<Contato> list()
        {
            try
            {
                return contextDB.Contato.Where(x => x.Status != StaticValues.ContatoStatus.EXCLUIDA).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Contato get(int contatoID)
        {
            try
            {
                return contextDB.Contato.Find(contatoID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void create(Contato contato)
        {
            try
            {
                contextDB.Contato.Add(contato);
                contextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Contato contato)
        {
            try
            {
                Contato oldContato = contextDB.Contato.Find(contato.ContatoID);
                oldContato.Nome = contato.Nome;
                oldContato.Telefone = contato.Telefone;
                oldContato.Cargo = contato.Cargo;
                oldContato.Celular = contato.Celular;
                oldContato.Email = contato.Email;
                oldContato.Status = contato.Status;
                oldContato.DataAlteracao = DateTime.Now;

                contextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int contatoID)
        {
            try
            {
                Contato delContato = contextDB.Contato.Find(contatoID);
                delContato.Status = StaticValues.ContatoStatus.EXCLUIDA;
                contextDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}