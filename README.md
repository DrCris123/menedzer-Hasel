# 🔐 Generator Haseł (Password Generator)

Nowoczesna aplikacja desktopowa do generowania bezpiecznych haseł lokalnie na Twoim komputerze.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp)
![WPF](https://img.shields.io/badge/WPF-Windows-0078D4?style=flat-square&logo=windows)
![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)

## ✨ Funkcje

- **🎲 Kryptograficznie bezpieczne generowanie** - wykorzystuje `RandomNumberGenerator` do tworzenia prawdziwie losowych haseł
- **📏 Regulowana długość** - od 4 do 128 znaków
- **🔤 Konfigurowalne typy znaków:**
  - Wielkie litery (A-Z)
  - Małe litery (a-z)
  - Cyfry (0-9)
  - Symbole specjalne (!@#$%^&*...)
- **👁️ Wykluczanie podobnych znaków** - opcja usunięcia mylących znaków (0, O, l, 1)
- **💪 Wskaźnik siły hasła** - wizualna ocena bezpieczeństwa wygenerowanego hasła
- **📋 Kopiowanie do schowka** - szybkie kopiowanie jednym kliknięciem
- **🎨 Nowoczesny interfejs** - ciemny motyw z czerwono-czarnym gradientem

## 🖼️ Zrzuty ekranu

```
┌─────────────────────────────────────┐
│  🔒 Generator Haseł              ✕  │
├─────────────────────────────────────┤
│ Wygenerowane Hasło:                 │
│ ┌─────────────────────────────┬───┐ │
│ │ Kliknij 'Generuj'...        │ 📋│ │
│ └─────────────────────────────┴───┘ │
│                                     │
│ Ustawienia Hasła:                   │
│ Długość: [━━━━━━━━━━━━━━━] 16      │
│ ☑ Wielkie litery    ☑ Małe litery  │
│ ☑ Cyfry             ☑ Symbole      │
│ ☐ Wyklucz podobne znaki            │
│                                     │
│ Siła Hasła:                         │
│ [████████░░] Silne                  │
│                                     │
│    [🔄 GENERUJ NOWE HASŁO]          │
└─────────────────────────────────────┘
```

## 🚀 Instalacja

### Wymagania systemowe
- Windows 10/11
- .NET 8.0 Runtime

### Kompilacja ze źródeł

1. Sklonuj repozytorium:
```bash
git clone https://github.com/DrCris123/menedzer-Hasel.git
cd menedzer-Hasel
```

2. Otwórz rozwiązanie w Visual Studio 2022 lub nowszym:
```bash
"Menedzer haseł.sln"
```

3. Skompiluj projekt:
   - Naciśnij `F5` lub wybierz `Build > Build Solution`
   - Plik wykonywalny znajdziesz w `bin/Debug/net8.0-windows/` lub `bin/Release/net8.0-windows/`

### Alternatywnie - kompilacja z wiersza poleceń

```bash
dotnet build -c Release
dotnet run --project "Menedzer haseł/Menedzer haseł.csproj"
```

## 💻 Użytkowanie

1. **Uruchom aplikację** - kliknij dwukrotnie na `Menedzer haseł.exe`
2. **Dostosuj ustawienia:**
   - Przesuń suwak, aby ustawić długość hasła
   - Zaznacz/odznacz typy znaków, które chcesz uwzględnić
   - Opcjonalnie włącz wykluczanie podobnych znaków
3. **Wygeneruj hasło** - kliknij przycisk "GENERUJ NOWE HASŁO"
4. **Skopiuj hasło** - kliknij ikonę 📋 obok wygenerowanego hasła

## 🔒 Bezpieczeństwo

- **Generowanie lokalne** - wszystkie hasła są generowane lokalnie na Twoim komputerze
- **Brak połączenia z internetem** - aplikacja nie wymaga ani nie używa połączenia internetowego
- **Kryptograficzna losowość** - wykorzystuje `System.Security.Cryptography.RandomNumberGenerator`
- **Brak przechowywania** - hasła nie są zapisywane ani logowane
- **Brak telemetrii** - aplikacja nie zbiera żadnych danych

## 🧮 Algorytm oceny siły hasła

Hasło jest oceniane na podstawie:
- **Długości** (8, 12, 16, 20+ znaków)
- **Różnorodności znaków** (wielkie/małe litery, cyfry, symbole)
- **Unikalności** (brak powtarzających się znaków)

Maksymalny wynik: 100 punktów

| Punkty | Ocena |
|--------|-------|
| 0-24   | Bardzo słabe |
| 25-49  | Słabe |
| 50-74  | Średnie |
| 75-89  | Silne |
| 90-100 | Bardzo silne |

## 🛠️ Technologie

- **.NET 8.0** - Najnowsza wersja platformy .NET
- **WPF (Windows Presentation Foundation)** - Framework UI dla aplikacji desktopowych Windows
- **C#** - Język programowania
- **XAML** - Język znaczników dla interfejsu użytkownika
- **RandomNumberGenerator** - Kryptograficznie bezpieczny generator liczb losowych

## 📝 Struktura projektu

```
menedzer-Hasel/
├── Menedzer haseł/
│   ├── MainWindow.xaml          # Interfejs użytkownika
│   ├── MainWindow.xaml.cs       # Logika aplikacji
│   ├── App.xaml                 # Globalne style i zasoby
│   ├── App.xaml.cs              # Punkt wejścia aplikacji
│   └── Menedzer haseł.csproj    # Plik projektu
└── README.md
```

## 🤝 Wkład w projekt

Chętnie przyjmujemy propozycje ulepszeń! Jeśli chcesz pomóc:

1. Forkuj projekt
2. Stwórz branch dla swojej funkcji (`git checkout -b feature/NowaFunkcja`)
3. Commituj zmiany (`git commit -m 'Dodaj nową funkcję'`)
4. Push do brancha (`git push origin feature/NowaFunkcja`)
5. Otwórz Pull Request

## 📋 Planowane funkcje

- [ ] Eksport wygenerowanych haseł do pliku
- [ ] Historia ostatnio wygenerowanych haseł (w pamięci)
- [ ] Własne zestawy znaków
- [ ] Tryb generowania haseł z fraz (passphrase)
- [ ] Obsługa wielu języków (EN, DE, FR)
- [ ] Tryb ciemny/jasny

## 📄 Licencja

Ten projekt jest udostępniony na licencji MIT - zobacz plik [LICENSE](LICENSE) po szczegóły.

## 👨‍💻 Autor

**DrCris123**

## ⚠️ Zastrzeżenie

Ta aplikacja służy do generowania haseł lokalnie i nie zapewnia funkcji zarządzania hasłami (przechowywania, organizacji). Do bezpiecznego przechowywania haseł rozważ użycie dedykowanego menedżera haseł takiego jak Bitwarden, KeePass lub 1Password.

---

⭐ Jeśli ten projekt okazał się pomocny, zostaw gwiazdkę na GitHub!
