# OPBlagajna
Projekt za kolegij Objektno programiranje.
Program predstavlja rad blagajne. Korisnik ima mogućnost odabira kupljenih proizvoda i pravljenja računa.
Postoji gotova baza proizvoda iz koje se odabiru proizvodi.
Račun se sprema u tekstualnom obliku kako bi se omogućilo printanje.

Pri pokretanju programa otvara se sučelje na kojem postoji mogućnost pretraživanja proizvoda u bazi po imenu ili po id-u (barcode). Klikom na proizvod on se odabire i potrebno je unijeti željenu količinu proizvoda. Ako se radi u proizvodu promjenjive količine (recimo voće) moguće je unijeti decimalne brojeve, a ako se radi o nekom predmetu tada je moguće unositi samo cijele brojeve.
Pritiskom na gumb dodaj, proizvod se dodaje na listu koja predstavlja račun. Proizvodi su u bazi navedeni bez PDV-a s razinom PDV-a u koju spadaju (tri razine od 5%, ). Temeljem razine PDV-a i količine proizvoda računa se ukupna cijena proizvoda i ukupna cijena koju je potrebno platiti.
Kad je unos proizvoda završen, unosi se primljena količina novca i pritišće se na gumb "OK". Ako je unesena količina dovoljna za plaćanje izlazi pop-up dialog koji prikazuje koliko je potrebno platiti, koliko je novaca primljeno i koliko novaca treba vratiti. Također se pravi i tekstualni zapis računa u "C:\Users\Public\Documents\Racuni" folderu.
Nakon toga, blagajna se vraća na početno stanje u moguće je praviti nove račune.
