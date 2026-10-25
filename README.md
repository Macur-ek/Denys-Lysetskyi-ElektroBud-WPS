# Elektro-Bud

## Opis problemu
Firma Elektro-Bud potrzebuje aplikacji do ewidencji produktów i kontroli stanów magazynowych. 
Ręczne prowadzenie ewidencji może powodować pomyłki w ilościach towarów i utrudniać sprawdzenie wcześniejszych operacji.
Celem aplikacji jest umożliwienie użytkownikowi zarządzania podstawowymi danymi magazynowymi za pomocą czytelnego interfejsu desktopowego.

# Wymagania funkcjonalne
1. Wyświetlanie katalogu produktów.
2. Prezentowanie aktualnego stanu magazynowego.
3. Dodawanie nowych produktów.
4. Rejestrowanie przyjęć magazynowych.
5. Rejestrowanie wydań magazynowych.
6. Blokowanie wydania większej ilości towaru, niż znajduje się w magazynie.
7. Prowadzenie historii operacji z datą i ilością.
8. Zapisywanie i odczytywanie danych po ponownym uruchomieniu programu.

# Wymagania niefunkcjonalne
1. Aplikacja działa na systemie Windows i korzysta z technologii WPF.
2. Interfejs jest czytelny i w języku polskim.
3. Program sprawdza poprawność danych wprowadzanych przez użytkownika.
4. Kod jest podzielony na modele danych, interfejs i logikę aplikacji.
5. Dane są przechowywane lokalnie w plikach JSON.
6. Błędy odczytu i zapisu są zgłaszane użytkownikowi.
