# Beauty & More - Drogerijska radnja

🌸 **Beauty & More** je aplikacija namijenjena kozmetičkim radnjama koja omogućava jednostavno upravljanje zaposlenima, proizvodima, prodajnim artiklima, kao i izdavanje računa. Aplikacija nudi različite mogućnosti za administratore i zaposlene, pregled i manipulaciju podacima, kao i podršku za različite teme i jezike.

---

## 📑 Sadržaj

- [Početna stranica](#početna-stranica)
- [Administratorske funkcije](#administratorske-funkcije)
- [Funkcije za zaposlene](#funkcije-za-zaposlene)
- [Računi i korpa](#računi-i-korpa)
- [Različite teme i jezičke opcije](#višekratne-teme-i-jezičke-opcije)
- [Tehnička dokumentacija](#tehnička-dokumentacija)

---

## 🌐 Početna stranica

- **Prijava**: Omogućava prijavu i direktorima (administratorima) i zaposlenima.
- **Odabir jezika**: Podržava dva jezika: **Engleski** i **Srpski**.
- **Pocetna stranica** sadrži:
  - **Login formular** sa poljima za korisničko ime i lozinku.
  - Mogućnost odabira jezika.

---

## 👩‍💼 Administratorske funkcije

Direktori imaju sledeće mogućnosti:

- **CRUD operacije nad zaposlenima**:
  - Dodavanje, uređivanje i brisanje zaposlenih.
  - Pregled osnovnih informacija o zaposlenima (ime, pozicija, radno vrijeme, datum zaposlenja, plata..)
  
- **Podešavanje tema**:
  - Tri dostupne teme: **Svijetla**, **Tamna**, **Podrazumijevana**
  
  
---

## 👨‍💼 Funkcije za zaposlene

Zaposleni imaju sljedeće opcije:

- **Pregled i CRUD operacije nad kategorijama proizvoda**:
  - Pregled proizvoda po kategorijama.
  - Dodavanje novih kategorija, uređivanje postojećih i brisanje.
  
- **Pregled prodajnih artikala**:
  - Pregled svih dostupnih proizvoda.
  - Detaljan pregled proizvoda sa opisom, cijenom i količinom.
  
- **Pregled računa**:
  - Zaposleni mogu pretraživati račune po datumima.
  - Za svaki račun prikazuju se sve stavke sa cijenama, količinom i nazivom.
  
- **Izdavanje računa**:
  - Dodavanje proizvoda u korpu.
  - Pregled korpe proizvoda sa odabranim količinama.
  - Generisanje računa na osnovu odabranih stavki.
  - Definisanje načina plaćanja (gotovina, kartica) i kase na kojoj se izdaje račun.

---

## 🛒 Računi i korpa

- **Korpa**:
  - Omogućeno je dodavanje proizvoda u korpu i pregled  ukupne cijene i pojedinačne po proizvodima.
  - Moguće je uređivati količine proizvoda u korpi na intuitivan način.

- **Izdavanje računa**:
  - Kada su stavke u korpi odabrane, zaposleni može generisati račun sa ukupnim iznosom.

---

## 🎨 Različite teme i jezičke opcije

- **Podrška za 3 teme**: 
  - **Svijetla** (Luminous): Lagana i prijatna tema roze nijansi za administratora i blago zelene za zaposlene.
  - **Tamna** (Dark): Tema sa tamnijim tonovima pogodna za noćnu upotrebu, kod administratora tamno ljubičasta a kod zaposlenog tamno zelena.
  - **Automatska** (Auto): Tema koja se defaultno postavlja.

- **Različiti jezici**: 
  - Podržani su **Engleski** i **Srpski** jezici za sve tekstove u aplikaciji.
  - Mogućnost brze promjene jezika putem menija na početnoj stranici.

---

## ⚙️ Tehnička dokumentacija

### Tehnologije

- **Frontend**: WPF (Windows Presentation Foundation) za desktop aplikaciju.
- **Backend**: C# sa ASP.NET Core za API.
- **Baza podataka**: MySQL Server za skladištenje podataka.

---

### 🖥️ Instalacija

1. **Klonirajte repozitorijum**:
   ```bash
   git clone https://github.com/Tijana15/Human-Computer-Interaction-First.git
