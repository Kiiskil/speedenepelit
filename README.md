1.6.2018    v1.0    Initial Draft
Speeden Eepelit / Sepen Sepelit / 

Sisältö:
    GUI
    
        -Äänet
            -Ulkoiset valmiit
            -Omat
            
        -Grafiikka
            -Ulkoiset valmiit
            -Omat
            -Animointi(?)
            
    MySql
        -nimim / opiskelijanro
        -Pelitunniste
        -HiScores
        
    Tiedostoon kirjoitus
        -Varmuuskopiot tjsp
        -Loki

Nopeuspeli (4 nappia)
    Käytettävät tekniikat:
        -State Machine(?)
        -List
    -Peli arpoo kiihtyvällä tahdilla 1..4, vertaa edelliseen arpomiseen
        -Arvot talteen listaan
    -Pelaaja klikkaa painikkeita (näppäimistö tai hiiri) valojen syttymis järjestyksessä
        -Muuttujaa verrataan listan ensimmäiseen elementtiin, jos sama pisteet++ ja list.first delete
    -Väärä syöte pysäyttää pelin, ja siirtää game over screeniin
    -Tulosta verrataan HiScore databaseen, jos top X lisätään oikealle paikalle.
    -Game over näkymässä: HiScoret, takaisin valikkoon painike ja uusi peli painike
    
Korttipeli (pun / musta)
    Käytettävät tekniikat:
        -Stack
    -Vaikeustaso:  1) väri 2) maa
    -Peli tarjoaa pelaajalle korttia nurin päin ja kysyy onko kortti punainen vai musta  // maata
    -Oikealla arvauksella kortti jää oikein päin näkyviin ja peli jatkuu
    -Tulokset daatabaseen
    
Ajan arviointi
    -Käyttäjälle annetaan kohdeaika
    -Käyttäjä aloittaa pelin painamalla spacebarin pohjaan ja lopettaa nostamalla ylös
    -Peli näyttää kuluneen ajan x.xxx s, ja antaa tuloksen tavoiteajan ja käyttäjän tuloksen erotuksen itseisarvona
    -Tulokset daatabaseen
    
HiScoret
    -Koostettu screeni pisteiden mukaan
    -Pelikohtainen
    
Projektin hallinta:
!    -Merkintätapojen sopiminen
        -kommentointi
        -muuttujien&vakioiden nimeäminen
    -Työnjako
    -Aikataulutus
    -Työvaiheiden määrittely
!    -Projektin määrittely
    
        