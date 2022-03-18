import { Burad } from "./burad.js";
import { Radnik } from "./radnik.js";

export class Destilerija{
    constructor(naziv,lokacija){
        this.naziv=naziv;
        this.lokacija=lokacija;
        this.burad=[];
        this.radnici=[];
        this.proizvodi=[];
        this.kontejner=null;
    }
    
    DodajBurad(element){
        this.burad.push(element);
    }
    
    DodajRadnike(element){
        this.radnici.push(element);
    }

    DodajProizvode(element){
        this.proizvodi.push(element);
    }

    crtajDestileriju(host){
        let div=document.createElement("div");
        div.classList.add("glavniDiv");

        let naslovDestilerije=document.createElement("h2");
        naslovDestilerije.innerHTML="Destilerija "+this.naziv;
        naslovDestilerije.classList.add("nazivDestilerije");
        div.appendChild(naslovDestilerije);

        let divSpoljasnji=document.createElement("div");
        divSpoljasnji.classList.add("divSpoljasnji");

        let divForma=document.createElement("div");
        let divFormaBurad=document.createElement("div");

        //Kreiranje Forme za unos i izmenu Buradi!
        divForma.classList.add("divForme");
        divFormaBurad.classList.add("divFormaBurad");

        //Unos Kolicine godine i proizvoda
        let labela=document.createElement("label");
        labela.innerHTML="Kolicina:";
        divFormaBurad.appendChild(labela);
        let kolicina=document.createElement("input");
        kolicina.type="number";
        kolicina.classList.add("kolicina");
        divFormaBurad.appendChild(kolicina);
        divFormaBurad.appendChild(document.createElement("br"));

        labela=document.createElement("label");
        labela.innerHTML="Godina:";
        divFormaBurad.appendChild(labela);
        let godina=document.createElement("input");
        godina.type="number";
        godina.classList.add("godina");
        divFormaBurad.appendChild(godina);
        divFormaBurad.appendChild(document.createElement("br"));

        //Dodavanje opcije
        labela=document.createElement("label");
        labela.innerHTML="Prozivod:";
        divFormaBurad.appendChild(labela);
        let selekcija=document.createElement("select");
        let opcija;
        this.proizvodi.forEach(x=>{
            opcija=document.createElement("option");
            opcija.value=x.id;
            opcija.innerHTML=x.naziv;
            selekcija.appendChild(opcija);
        });
        divFormaBurad.appendChild(selekcija);
        divFormaBurad.appendChild(document.createElement("br"));

        //Dugme za dodavanje bureta
        let dugmeDodajBurad=document.createElement("button");
        dugmeDodajBurad.innerHTML="Dodaj";
        dugmeDodajBurad.onclick=()=>{
            let kol=divFormaBurad.querySelector(".kolicina").value;
            let god=divFormaBurad.querySelector(".godina").value;
            let pro=divFormaBurad.querySelector("select").selectedOptions[0].value;

            if(kol=="undefined" || god=="undefined"){
                alert("Niste uneli ispravne podatke.");
                return;
            }
            if(kol=="" || god==""){
                alert("Niste uneli ispravne podatke.");
                return;
            }
            this.dodajBuradDugme(parseInt(kol),parseInt(god),pro,divZaCrtanje);
            this.updateSelectRadnik(divFormaRadnik.querySelector("select"),divFormaRadnik);
        }
        divFormaBurad.appendChild(dugmeDodajBurad);

        //Dugme za brisanje bureta
        let dugmeBrisiBure=document.createElement("button");
        dugmeBrisiBure.innerHTML="Obrisi";
        dugmeBrisiBure.onclick=()=>{
            let kol=divFormaBurad.querySelector(".kolicina").value;
            let god=divFormaBurad.querySelector(".godina").value;
            let pro=divFormaBurad.querySelector("select").selectedOptions[0].value;

            if(kol===undefined || god===undefined){
                alert("Niste uneli ispravne podatke.1");
                return;
            }
            if(kol=="" || god==""){
                alert("Niste uneli ispravne podatke.2");
                return;
            }
            this.obrisiBurad(parseInt(kol),parseInt(god),pro,divZaCrtanje);
            this.updateSelectRadnik(divFormaRadnik.querySelector("select"),divFormaRadnik);
        }

        divFormaBurad.appendChild(dugmeBrisiBure);
        divForma.appendChild(divFormaBurad);

        //Kreiranje forme za unos radnika!
        let divFormaRadnik=document.createElement("div");
        divFormaRadnik.classList.add("divFormaRadnik");

        labela=document.createElement("label");
        labela.innerHTML="Ime:";
        divFormaRadnik.appendChild(labela);
        let ime=document.createElement("input");
        ime.type="name";
        ime.classList.add("ime");
        divFormaRadnik.appendChild(ime);
        divFormaRadnik.appendChild(document.createElement("br"));

        labela=document.createElement("label");
        labela.innerHTML="Prezime:";
        divFormaRadnik.appendChild(labela);
        let prezime=document.createElement("input");
        prezime.type="name";
        prezime.classList.add("prezime");
        divFormaRadnik.appendChild(prezime);
        divFormaRadnik.appendChild(document.createElement("br"));

        selekcija=document.createElement("select");
        this.burad.forEach(x=>{
            opcija=document.createElement("option");
            opcija.value=x.id;
            opcija.innerHTML=x.proizvodnja();
            selekcija.appendChild(opcija);
        });
        labela=document.createElement("labela");
        labela.innerHTML="Proizvodnja:";
        divFormaRadnik.appendChild(labela);
        divFormaRadnik.appendChild(selekcija);

        //Dugme za prikazivanje radnika
        let divTabele=document.createElement("div");
        divTabele.classList.add(".divTabele");
        let dugmeRadnikPrikaz=document.createElement("button");
        dugmeRadnikPrikaz.innerHTML="Prikazi";
        dugmeRadnikPrikaz.onclick=()=>{
            let sel=divFormaRadnik.querySelector("select").selectedOptions[0].value;
            this.crtajRadnike(sel,divTabele,divForma);
        }
        divFormaRadnik.appendChild(document.createElement("br"));
        divFormaRadnik.appendChild(dugmeRadnikPrikaz);

        //Dugme za prikazivanje svih radnika
        let dugmeSviRadnici=document.createElement("button");
        dugmeSviRadnici.innerHTML="Svi radnici";
        dugmeSviRadnici.onclick=()=>{
            this.crtajSveRadnike(divTabele,divForma);
        }
        divFormaRadnik.appendChild(dugmeSviRadnici);
        divFormaRadnik.appendChild(document.createElement("br"));

        //Dugme dodaj Radnika Na Proizvodnju
        let dugmeRadnikProizvodnja=document.createElement("button");
        dugmeRadnikProizvodnja.innerHTML="Dodaj u proizvodnju";
        dugmeRadnikProizvodnja.onclick=()=>{
            let ime=divFormaRadnik.querySelector(".ime").value;
            let prezime=divFormaRadnik.querySelector(".prezime").value;
            let sel=divFormaRadnik.querySelector("select").selectedOptions[0].value;

            if(ime==="" || prezime===""){
                alert("Niste uneli ispravne podatke.");
                return;
            }

            this.dodajRadnikaNaProizvodnju(ime,prezime,sel);
        }
        divFormaRadnik.appendChild(dugmeRadnikProizvodnja);
        divForma.appendChild(divFormaRadnik)
        divSpoljasnji.appendChild(divForma);

        let divZaCrtanje=document.createElement("div");
        divZaCrtanje.classList.add("divZaCrtanje");
        this.burad.forEach(x=>{
            x.crtajBurad(divZaCrtanje);
        });
        divSpoljasnji.appendChild(divZaCrtanje);
        div.appendChild(divSpoljasnji);
        
        this.kontejner=div;
        host.appendChild(this.kontejner);
    }

    async obrisiBurad(kolicina,godina,idProizvoda,host){
        let proizvod;
        this.proizvodi.forEach(x=>{
            if(x.id==idProizvoda){
                proizvod=x.naziv;
            }
        });

        let id;
        let bure;
        this.burad.forEach(x=>{
            if(x.kolicina==kolicina && x.godina==godina && x.nazivProizvoda==proizvod){
                bure=x;
                id=x.id;
            }
        });

        
        if(id<0 || bure===undefined){
            alert("Niste uneli ispravne podatke4");
            return;
        }
        
        
        host.removeChild(bure.kontejner);
        this.burad=this.burad.filter(el=>el.id!=id);
        await fetch("https://localhost:5001/Burad/ObrisiBure/"+id,{method:"DELETE"})
                    .then(p=>{
                        if(p.ok){
                            fetch("https://localhost:5001/Proizvodnja/ObrisiProizvodnju/"+id,{method:"DELETE"})
                                .then(s=>{
                                    if(s.ok)
                                    {
                                        alert("Bure je obrisano");
                                    }
                                });
                        }
                        else{
                            alert("Bure nije obrisano.");
                        }
                    });
        
    }

    async dodajBuradDugme(kolicina,godina,idProizvoda,host){
        if(kolicina<0 || godina<0 || idProizvoda===0){
            alert("Niste uneli ispravne podatke");
            return;
        }
        let proizvod;
        this.proizvodi.forEach(x=>{
            if(x.id==idProizvoda){
                proizvod=x.naziv;
            }
        });

        let pom;
        await fetch("https://localhost:5001/Burad/DodajBurad/"+kolicina+"/"+godina+"/"+idProizvoda,{method:"POST"})
            .then(x=>{
                if(x.ok){
                    x.json().then(data=>{
                        pom=new Burad(data,kolicina,godina,proizvod);
                        pom.crtajBurad(host)
                        this.DodajBurad(pom);
                    })
                }
            });
    }

    updateSelectRadnik(element,host){
        host.removeChild(element);
        element=document.createElement("select");
        this.burad.forEach(x=>{
            let opcija=document.createElement("option");
            opcija.value=x.id;
            opcija.innerHTML=x.proizvodnja();
            element.appendChild(opcija);
        });
        host.appendChild(element);
    }

    async crtajRadnike(id,host,host2){
        this.radnici=[];
        let tabela = host.querySelector("table");
        if(tabela!=undefined){
            host.removeChild(tabela);
        }

        await fetch("https://localhost:5001/Proizvodnja/RadniciRadiliNa/"+id,{method: "GET"})
            .then(p=>{
                if(p.ok)
                {
                    p.json().then(data=>{
                        data.forEach(x=>{
                            this.DodajRadnike(new Radnik(x.id,x.ime,x.prezime));
                        });

                        let table = document.createElement("table");
                        let thead = document.createElement("thead");
                        let tbody = document.createElement("tbody");

                        //--thead--
                        let tr=document.createElement("tr");
                        let th=document.createElement("th");
                        th.innerHTML="Ime";
                        tr.appendChild(th);
                        th=document.createElement("th");
                        th.innerHTML="Prezime";
                        tr.appendChild(th);
                        thead.appendChild(tr);
                        table.appendChild(thead);

                        //--tbody--
                        this.radnici.forEach(el=>{
                            tr=document.createElement("tr");
                            let td=document.createElement("td");
                            td.innerHTML=el.ime;
                            tr.appendChild(td);
                            td=document.createElement("td");
                            td.innerHTML=el.prezime;
                            tr.appendChild(td);
                            tbody.appendChild(tr);
                        });

                        table.appendChild(tbody);
                        host.appendChild(table);
                        host2.appendChild(host);
                    });
                }
                else{
                    alert("Nisu pronadjeni radnici.");
                }
        });
    }

    async crtajSveRadnike(host,host2){
        this.radnici=[];
        let tabela = host.querySelector("table");
        if(tabela!=undefined){
            host.removeChild(tabela);
        }

        await fetch("https://localhost:5001/Radnik/VratiRadnika",{method: "GET"})
            .then(p=>{
                if(p.ok)
                {
                    p.json().then(data=>{
                        data.forEach(x=>{
                            this.DodajRadnike(new Radnik(x.id,x.ime,x.prezime));
                        });

                        let table = document.createElement("table");
                        let thead = document.createElement("thead");
                        let tbody = document.createElement("tbody");

                        //--thead--
                        let tr=document.createElement("tr");
                        let th=document.createElement("th");
                        th.innerHTML="Ime";
                        tr.appendChild(th);
                        th=document.createElement("th");
                        th.innerHTML="Prezime";
                        tr.appendChild(th);
                        thead.appendChild(tr);
                        table.appendChild(thead);

                        //--tbody--
                        this.radnici.forEach(el=>{
                            tr=document.createElement("tr");
                            let td=document.createElement("td");
                            td.innerHTML=el.ime;
                            tr.appendChild(td);
                            td=document.createElement("td");
                            td.innerHTML=el.prezime;
                            tr.appendChild(td);
                            tbody.appendChild(tr);
                        });

                        table.appendChild(tbody);
                        host.appendChild(table);
                        host2.appendChild(host);
                    });
                }
                else{
                    alert("Nisu pronadjeni radnici.");
                }
        });
    }

    async dodajRadnikaNaProizvodnju(ime,prezime,idBurad){
        this.radnici=[];
        await fetch("https://localhost:5001/Radnik/VratiRadnika",{method: "GET"})
            .then(p=>{
                if(p.ok)
                {
                    p.json().then(data=>{
                        data.forEach(x=>{
                            this.DodajRadnike(new Radnik(x.id,x.ime,x.prezime));
                        });

                        let id=0;
                        this.radnici.forEach(x=>{
                            if(x.ime===ime && x.prezime===prezime){
                                id=x.id;
                            }
                        });
                        if(id===0){
                            alert("Radnik sa ovim imenom ne postoji.");
                        }
                        
                        fetch("https://localhost:5001/Proizvodnja/DodajRadnikaNaProizvodnju/"+idBurad+"/"+id,{method:"POST"})
                            .then(pom=>{
                                if(pom.ok){
                                    alert("Radnik je dodat na proizvodnju.");
                                }
                                else{
                                    alert("Radnik nije dodat");
                                }
                            });
                    });
                }
            }); 
    }
}