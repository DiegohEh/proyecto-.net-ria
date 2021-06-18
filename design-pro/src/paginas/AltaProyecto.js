import { Link } from "react-router-dom";
import avatar from "../assets/proyecto.png";

function AltaProyecto() {
  return (
    <div className="container-proyecto">
      <div className="cuadro-proyecto-foto">
        <div className="alinear-vertical">
          <img src={avatar} className="avatar-proyecto" />
          <br />
          <br />
          <Link to="/">
            <button class="boton-navegacion-perfil">Cargar Imagen</button>
          </Link>
        </div>
      </div>
      <div className="cuadro-proyecto">
        <h2>Publicar Proyecto</h2>
        <label className="label-para-input">Titulo del Proyecto</label>
        <hr className="hr-proyecto" />
        <input
          class="input-datos-fit-proyecto "
          type="text"
          name="titulo"
          placeholder="Tu titulo aqui"
          required
        />
        <label className="label-para-input">Etiquetas</label>
        <hr className="hr-proyecto" />
        <input
          class="input-datos-fit-proyecto"
          type="text"
          name="etiquetas"
          placeholder="Tus etiquetas aqui"
          required
        />
        <label className="label-para-input">Herramientas Utilizadas</label>
        <hr className="hr-proyecto" />
        <input
          class="input-datos-fit-proyecto"
          type="text"
          name="herramientas"
          placeholder="Tus herramientas aqui"
          required
        />

        <label className="label-para-input">Categorias </label>
        <hr className="hr-proyecto" />
        <select className="categorias" name="some-select" id="some-select" multiple="multiple">
          <option>Black</option>
          <option>White</option>
          <option>Other</option>
        </select>
        <br></br>
        <Link to="/">
          <button class="boton-navegacion-perfil">Atras</button>
        </Link>
        <Link to="/">
          <button class="boton-navegacion-perfil">Publicar</button>
        </Link>
      </div>
    </div>
  );
}

export default AltaProyecto;
