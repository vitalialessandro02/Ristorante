using Ristorante.Test.Examples;
using Ristorante.Models.Repositories;
using Ristorante.Models.Context;
using Ristorante.Models.Repositories;

MyDbContext myDbContext = new MyDbContext(); 

var esempio = new DettaglioOrdineRepository(myDbContext);
var esempioPortata = new PortataRepository(myDbContext);
var PortataByPrezzo = new PortataRepository(myDbContext);
var PortataByOrdine = new OrdineRepository(myDbContext);
var esempioUtente = new UtenteRepository(myDbContext);

int i = 0;
var a = esempioUtente.getUtenteByEmail("woj");
var pippo = esempio.GetDettagliOrdine(0,1,out i,1,2);
var pluto = esempioPortata.GetPortate(0, 1, out i,Ristorante.Models.Enumeration.Tipologia.Primo);
var minnie = PortataByPrezzo.GetPortateByPrezzo(0, 1, out i, 62, 50, 1);
var topolino = PortataByOrdine.GetPortateByIdOrdine(0, 1, out i, 2);
var gabibbo = PortataByOrdine.GetOrdine(0, 2, out i, new DateTime(2024, 01, 01), new DateTime(2025, 01, 01), 4);
var shrek = esempioUtente.getUtenti(0, 2, out i, 3);

var example = new EntityFrameworkExample();
example.RunExample();
Console.ReadLine();
