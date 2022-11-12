﻿using Fluxus.Domain.Entities;
using Newtonsoft.Json;
using System.Data;
using System.Threading.Tasks;


namespace Fluxus.Infra.Repositories
{
    public class OrderRepository
    {
        public void Insert(Os body)
        {
            string json = JsonConvert.SerializeObject(body);
            Request.Post("os/post", json);
        }

        public void Update(Os body)
        {
            string json = JsonConvert.SerializeObject(body);
            Request.Put("os/put/" + body.Id, json);
        }

        public void UpdateInvoiceId(long id, long invoiceId)
        {
            Request.Put("os/updatefaturacod/" + id + "," + invoiceId, string.Empty);
        }

        public async void UpdateStatus(long id, string status)
        {
            await Task.Run(() => Request.Put("os/updatestatus/" + id + "," + status, string.Empty));
        }

        public void Delete(long id)
        {
            Request.Delete("os/delete/", id.ToString());
        }

        public DataTable GetIndexOpen()
        {
            string json = Request.Get("os/getordensdofluxo", string.Empty);
            return JsonConvert.DeserializeObject<DataTable>(json);
        }

        public DataTable GetOpenDone()
        {
            string json = Request.Get("os/getordensconcluidasafaturar", string.Empty);
            return JsonConvert.DeserializeObject<DataTable>(json);
        }

        public DataTable GetClosedByInvoiceId(long invoiceId)
        {
            string json = Request.Get("os/getordensfaturadas/", invoiceId.ToString());
            return JsonConvert.DeserializeObject<DataTable>(json);
        }

        public DataTable GetFiltered(string parameters)
        {
            string json = Request.Get("os/getfiltered/", parameters);
            return JsonConvert.DeserializeObject<DataTable>(json);
        }

        public DataTable GetProfessionalByInvoiceId(long invoiceId)
        {
            string json = Request.Get("os/getprofissionaisdafatura/", invoiceId.ToString());
            return JsonConvert.DeserializeObject<DataTable>(json);
        }

        public DataTable GetCitiesFromOrders()
        {
            string json = Request.Get("os/getcidadesdasordens", string.Empty);
            return JsonConvert.DeserializeObject<DataTable>(json);
        }

        public Os GetById(long id)
        {
            string json = Request.Get("os/getby/", id.ToString());
            return JsonConvert.DeserializeObject<Os>(json);
        }
    }
}
