import { Burad } from "./burad.js";
import { Radnik } from "./radnik.js";
import { Destilerija } from "./destilerija.js";
import { Proizvod } from "./proizvod.js";

let dest=new Destilerija("FrigoBora","Grdelica");

fetch("https://localhost:5001/Burad/VratiBurad",{method: "GET"})
    .then(p=>{
        p.json().then(b=>{
                b.forEach(br=>{
                    dest.DodajBurad(new Burad(br.id,br.kolicina,br.godina,br.naziv));
                });
                fetch("https://localhost:5001/Proizvod/VratiProizvode",{method:"GET"})
                    .then(p=>{
                        p.json().then(el=>{
                            el.forEach(x=>{
                                dest.DodajProizvode(new Proizvod(x.id,x.naziv));
                            });
                            dest.crtajDestileriju(document.body);
                        });
                    });
            });
    });

    let dest2=new Destilerija("Stefanovic","Beograd");

    fetch("https://localhost:5001/Burad/VratiBurad",{method: "GET"})
        .then(p=>{
            p.json().then(b=>{
                    b.forEach(br=>{
                        dest2.DodajBurad(new Burad(br.id,br.kolicina,br.godina,br.naziv));
                    });
                    fetch("https://localhost:5001/Proizvod/VratiProizvode",{method:"GET"})
                        .then(p=>{
                            p.json().then(el=>{
                                el.forEach(x=>{
                                    dest2.DodajProizvode(new Proizvod(x.id,x.naziv));
                                });
                                dest2.crtajDestileriju(document.body);
                            });
                        });
                });
        });

