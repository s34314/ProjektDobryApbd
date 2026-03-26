Decyzje projektowe:
Renter - jako funkcja od której inne "wypożyczają". Prezchowuje dane i je dystrybutuje. Łączy wszystkie inne klasy.
Sprzęt - Definiuje wszystko co łączy się z dostępnymi przedmiotami
User - Definiuje wszystko co jest złączone z użytkownikami



 EquService - Działa jako baza danych wszystkich przedmiotów w obiegu. Po każdej interakcji przeszukuje cały magazyn i sprawdza czy coś jest dostępne

RentalService - Decyduje czy dany przedmiot może zostać wydany danej osobie. Jest to swojego rodzaju "kasjer" który dystrybutuje dobrami



IEquipment - Interface oplatający EquipmentService.
Skopiowałem sposób zrobienia interface z przykładowego programu który Pan podał. (Tak jak większość funkcji/ klas w tym programie)






Każda klasa odpowiada za jedno zadanie, np.:
Renter.Overlaps sprawdza tylko daty, nie decyduje o wypożyczeniu.

EquipmentService: Odpowiada tylko za magazyn (dodaj, znajdź, usuń sprzęt).

RentalService: Odpowiada tylko za proces (sprawdź limity, stwórz wypożyczenie).


Zahowana "Kohezja" za pomocą limitów w User i statusami w ItemStatus.



Generalny podział był w dużej mierze zabrany z pliku podanego na teams… Zamieniłem tylko rzeczy które musiały być zmienione. Mam nadzieje że to nie problem :)