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
                              <div className="col-sx-6 col-md-8 col-lg-6 mt-5 landscape d-flex justify-content-center ">
                                      <img
                                          className="imagenPortada"
                                          src={fotoPortada}
                                          alt="Imagen de Portada"
                                      />

                                      
                                  </div>
                                  <div className="col-sx-6 col-md-6 col-lg-6 landscape">
                                      <h1 className="deslizarContenido margenTop30">Menoo!</h1>
                                      <p className="deslizarContenido">
                                            Crea y modifica la carta de tu negocio en minutos.<br />
                                      </p>
                                      <div className="containButton deslizarContenido">
                                          <a href="#obtenerPerspectiva"
                                          ><button aria-label="Descubrir" className="botonAzul">
                                                  Ingresar
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
