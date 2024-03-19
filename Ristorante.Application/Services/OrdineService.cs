﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ristorante.Application.Abstractions.Services;
using Ristorante.Models.Entities;
using Ristorante.Models.Enumeration;
using Ristorante.Models.Repositories;

namespace Ristorante.Application.Services
{
    public class OrdineService : IOrdineService
    {
        private readonly OrdineRepository _ordineRepository;
        private readonly DettaglioOrdineRepository _dettaglioOrdineRepository;
        private readonly PortataRepository _portataRepository;
        private double prezzo;
        private int nprimi;
        private int nsecondi;
        private int ncontorni;
        private int ndolci;
        private int nOrdine;
        


        public OrdineService(OrdineRepository ordineRepository, DettaglioOrdineRepository dettaglioOrdineRepository, PortataRepository portataRepository)
        {
            _ordineRepository = ordineRepository;
            _dettaglioOrdineRepository = dettaglioOrdineRepository;
            _portataRepository = portataRepository;
        }

        public void addOrdine(Ordine ordine, List<int> portate, List<int> quantita)
        {
            _ordineRepository.Aggiungi(ordine);
            _ordineRepository.Save();
            nOrdine = ordine.IdOrdine;
            for(int i = 0; i < portate.Count(); i++)
            {
                var dettaglioOrdine = new DettagliOrdine();
                dettaglioOrdine.IdPortata = portate.ElementAt(i);
                dettaglioOrdine.IdOrdine = ordine.IdOrdine;
                dettaglioOrdine.Quantita = quantita.ElementAt(i);
                _dettaglioOrdineRepository.Aggiungi(dettaglioOrdine);
                _dettaglioOrdineRepository.Save();
            }

            nprimi = CountByTipologia(Tipologia.Primo, portate);
            nsecondi = CountByTipologia(Tipologia.Secondo, portate);
            ncontorni = CountByTipologia(Tipologia.Contorno, portate);
            ndolci = CountByTipologia(Tipologia.Dolce, portate);

            if (nprimi == 0 || nsecondi == 0 || ncontorni == 0 || ndolci == 0) this.prezzo= prezzoCalcolato(portate,quantita);
          
            else prezzo = prezzoCalcolato(portate, quantita) - Sconto(portate);
            




        } 

        private double Sconto(List<int> portate)
        {
            List<Portata> portateordinate = _portataRepository.GetPortate(portate);


            

             double prezzo = (maxForTipologia(Tipologia.Primo, portate) + maxForTipologia(Tipologia.Secondo, portate)
                 + maxForTipologia(Tipologia.Contorno, portate) + maxForTipologia(Tipologia.Dolce, portate))*0.1;

            return prezzo;
        }



        private int CountByTipologia(Tipologia tipologia, List<int> portate)
        {
            List<Portata> portateordinate = _portataRepository.GetPortate(portate);
            

            return portateordinate.Where(w => w.TipologiaPortata.Equals(tipologia)).Count();
        }


        private double maxForTipologia(Tipologia tipologia, List<int> portate)
        {
            List<Portata> portateordinate = _portataRepository.GetPortate(portate);

           return  portateordinate.Where(w => w.TipologiaPortata.Equals(tipologia)).Select(w => w.Prezzo).Max();
        }


        private double prezzoCalcolato(List<int> portate,List<int> quantità)
        {
          
            var prezzi = _portataRepository.GetPortate(portate).Select(w => w.Prezzo);
            double prezzo=0.0;
            for(int i = 0; i < portate.Count(); i++)
            {
                prezzo +=prezzi.ElementAt(i) * quantità.ElementAt(i);
            }


            return prezzo;
        }


        public List<Ordine> getOrdini()
        {
            return new List<Ordine>();
        }

        public List<Ordine> getOrdini(int from, int num, out int totalNum, DateTime dataInizio, DateTime dataFine, int idUtente)
        {
            return _ordineRepository.GetOrdine(from, num, out totalNum, dataInizio, dataFine, idUtente);
        }

        public double GetPrezzo()
        {
            return prezzo;
            
        }

        public int GetNumeroOrdine()
        {
            return nOrdine; 

        }


    }
}
