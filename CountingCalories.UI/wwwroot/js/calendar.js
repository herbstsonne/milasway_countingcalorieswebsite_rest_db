function Kalender(Monat, Jahr, KalenderId) {

    const Monatsname = ["Januar", "Februar", "März", "April", "Mai", "Juni",
        "Juli", "August", "September", "Oktober", "November", "Dezember"],
        Tag = ["Mo", "Di", "Mi", "Do", "Fr", "Sa", "So"];

    // aktuelles Datum für die spätere Hervorhebung ermitteln
    const jetzt = new Date();
    let DieserTag = -1;
    if ((jetzt.getFullYear() == Jahr) && (jetzt.getMonth() + 1 == Monat))
        DieserTag = jetzt.getDate();

    // ermittle Wochentag des ersten Tags im Monat halte diese Information in Start fest
    // getDay liefert 0..6 für So..Sa. Wir möchten aber Mo=0 bis So=6, darum +6 und mod 7.
    const Zeit = new Date(Jahr, Monat - 1, 1);
    const Start = (Zeit.getDay() + 6) % 7;

    // die meisten Monate haben 31 Tage...
    let Stop = 31;

    // ...April (4), Juni (6), September (9) und November (11) haben nur 30 Tage...
    if (Monat == 4 || Monat == 6 || Monat == 9 || Monat == 11)--Stop;

    // ...und der Februar nur 28 Tage...
    if (Monat == 2) {
        Stop = Stop - 3;
        // ...außer in Schaltjahren
        if (Jahr % 4 == 0) Stop++;
        if (Jahr % 100 == 0) Stop--;
        if (Jahr % 400 == 0) Stop++;
    }

    const tabelle = document.getElementById(KalenderId);
    if (!tabelle)
        return false;
    // schreibe Tabellenüberschrift
    let Monatskopf = Monatsname[Monat - 1] + " " + Jahr,
        caption = tabelle.createCaption();
    caption.innerHTML = Monatskopf;

    // schreibe Tabellenkopf
    let row = tabelle.insertRow(0);
    for (let i = 0; i < 7; i++) {
        let cell = row.insertCell(i);
        cell.innerHTML = Tag[i];
    }

    // ermittle Tag und schreibe Zeile
    let Tageszahl = 1;

    // Monate können 4 bis 6 Wochen berühren. Darum laufen, bis die Tageszahl hinter dem Monatsletzen liegt.
    for (let i = 0; Tageszahl <= Stop; i++) {
        let row = tabelle.insertRow(1 + i);
        for (let j = 0; j < 7; j++) {
            let cell = row.insertCell(j);

            // Zellen vor dem Start-Tag in der ersten Zeile und Zeilen nach dem Stop-Tag werden leer aufgefüllt
            if (((i == 0) && (j < Start)) || (Tageszahl > Stop)) {
                cell.innerHTML = ' ';
            }
            else {
                // normale Zellen werden mit der Tageszahl befüllt und mit der Klasse Kalendertag markiert
                cell.innerHTML = Tageszahl;
                cell.className = 'kalendertag'

                // und der aktuelle Tag (heute) wird noch einmal speziell mit der Klasse "heute" markiert
                if (Tageszahl == DieserTag) {
                    cell.className = cell.className + ' heute';
                }

                Tageszahl++;
            }
        }
    }
    return true;
}

function ueberschriftEinfuegen() {
    const tabelle = document.getElementById('tabelle');
    // schreibe Tabellenüberschrift
    const caption = tabelle.createCaption();
    caption.innerHTML = 'Überschrift';
}

function zeileEinfuegen() {
    const tabelle = document.getElementById('tabelle');
    // schreibe Tabellenzeile
    const Reihe = tabelle.insertRow(0);
    for (let i = 0; i < 7; i++) {
        let inhalt = 'Zelle ' + (i + 1),
            zelle = reihe.insertCell();
        zelle.innerHTML = inhalt;
    }
}