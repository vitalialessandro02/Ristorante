# Ristorante
Nella schermata iniziale per connettersi al server usare come nome server "localhost" e in autenticazione selezionare "Autenticazione di Windows".
Creare l'account di accesso "ristorante" con nome utente "ristorante" e password "ristorante" con credenziali SQL server togliendo la spunta su "Applica criteri password".
Una volta scaricato il progetto tramite GitHub eseguire il file script.sql su SQL server.
Nell account "ristorante" impostare come database predefinito "Ristorante" e, sulla sezione "Mapping Utente", selezionare "public" e "db_owner".

Sulla pagina swagger, nelle sezioni newOrdine e getOrdini il campo "email" si riferisce alle email degli utenti registrati.
Nel campo "portate" della sezione newOrdine scrivere l'elenco delle portate utilizzando gli id visibili tramite getPortate e per ogni portata scrivere, nello stesso ordine, le quantità associate.
