using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRecibos.Models;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace ApiRecibos.Repositories
{
    public class RecibosRepository
    {
        RecibosContext context;

        public RecibosRepository(RecibosContext context)
        {
            this.context = context;
        }

        public IEnumerable<Recibo> GetAll()
        {
            return context.Recibos;
        }

        public Recibo GetReciboById(int id)
        {
            var recibo = context.Recibos.FirstOrDefault(x=>x.Id == id);
            return recibo;
        }

        public void Create(Recibo recibo)
        {
            context.Add(recibo);
            context.SaveChanges();
        }

        public void Update(int id, Recibo recibo)
        {
            context.Entry(recibo).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var recibo = context.Recibos.FirstOrDefault(x => x.Id == id);
            context.Remove(recibo);
            context.SaveChanges();
        }
    }
}
