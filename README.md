# Ristorante
ISTRUZIONI AVVIO
Nella schermata iniziale per connettersi al server usare come nome server "localhost" e in autenticazione selezionare "Autenticazione di Windows".
Creare l'account di accesso "ristorante" con nome utente "ristorante" e password "ristorante" con credenziali SQL server togliendo la spunta su "Applica criteri password".
Una volta scaricato il progetto tramite GitHub eseguire il file script.sql su SQL server.
Nell account "ristorante" impostare come database predefinito "Ristorante" e, sulla sezione "Mapping Utente", selezionare "public" e "db_owner".
Avviare l'applicazione da Visual Studio usando come progetto di avvio "Ristorante.Web - Production".
ISTRUZIONI UTILIZZO
Sulla pagina swagger, nelle sezione token il campo "username" si riferisce all'email dell'utente che vuole accedere.
Nel campo "portate" della sezione newOrdine scrivere l'elenco delle portate utilizzando gli id visibili tramite getPortate e per ogni portata scrivere, nello stesso ordine, le quantità associate.
Nel campo idDaVisualizzare della sezione getOrdini, se si è Amministratore, scrivere -1 se si vogliono vedere tutti gli ordini.
