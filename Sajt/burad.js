export class Burad{
    constructor(id,kolicina,godina,nazivProizvoda){
        this.id=id;
        this.kolicina=kolicina;
        this.godina=godina;
        this.nazivProizvoda=nazivProizvoda;
        this.kontejner=null;
    }

    crtajBurad(host){
        let div=document.createElement("div");
        div.innerHTML=`Naziv: ${this.nazivProizvoda}<br/>Kolicina: ${this.kolicina}L<br/>Godina: ${this.godina}`;
        div.classList.add("divBurad");
        this.kontejner=div;
        host.appendChild(this.kontejner);
    }

    proizvodnja(){
        return `${this.nazivProizvoda} ${this.godina} ${this.kolicina}L`;
    }
}