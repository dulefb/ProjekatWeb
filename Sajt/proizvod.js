export class Proizvod{
    constructor(id,naziv){
        this.id=id;
        this.naziv=naziv;
    }

    loguj(){
        console.log(`|${this.id}|${this.naziv}|`);
    }
}