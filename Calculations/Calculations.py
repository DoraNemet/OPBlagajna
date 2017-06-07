def IzracunCijeneSPorezom(cijena, porez):
    if porez == 1:
        return cijena * 1.25
    if porez == 2:
        return cijena * 1.05
    if porez == 3:
        return cijena * 1.13

def IzracunKonacneCijeneStavke(cijena, kolicina):
    return cijena * kolicina