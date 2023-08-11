import React, { Component } from 'react';

const currentURL = window.location.href
var fotoPortada = currentURL + "/assets/img/imageHeader.svg";


export class Home extends Component {
  static displayName = Home.name;

  render() {
      return (
          <div className=" fondoAmarillo">
        <div className="home">

                  <div className="portada">
                      <div className="">
                          
                              <div className="row justify-content-evenly align-items-center">
                                  <div className="col-sx-6 col-md-8 col-lg-6 mt-5 landscape">
                                      <img
                                          className="imagenPortada"
                                          src={fotoPortada}
                                          alt="Imagen de Portada"
                                      />

                                      
                                  </div>
                                  <div className="col-sx-6 col-md-6 col-lg-6 landscape">
                                      <h1 className="deslizarContenido margenTop30">Virtual Menú</h1>
                                      <p className="deslizarContenido">
                                          Digitalizamos el menú de su negocio <br />
                                          y creamos un Código QR que permite a sus clientes <br />
                                          leer la carta en sus dispositivos personales.
                                      </p>
                                      <div className="containButton deslizarContenido">
                                          <a href="#obtenerPerspectiva"
                                          ><button aria-label="Descubrir" className="botonAzul">
                                                  Descubrir
                                              </button></a
                                          >
                                      </div>
                                  </div>
                              </div>
                          
                      </div>
                  </div>


            </div>
          </div>
    );
  }
}
