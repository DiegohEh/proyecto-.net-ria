import avatar from "../assets/avatar.png";
import { Link } from "react-router-dom";

function PaginaPerfil() {
  return (
    <div className="container-perfil">
      <div className="cuadro-perfil-foto">
        <div className="alinear-vertical">
          <img src={avatar} className="avatar" />
          <br />
          <br />
          <Link to="/">
            <button class="boton-navegacion-perfil">Cargar Imagen</button>
          </Link>
        </div>
      </div>
      <div className="cuadro-perfil">
        <div className="alinear-vertical">
          <h2>Editar mis Datos</h2>
          <input
            class="input-datos-fit"
            type="text"
            name="nombre"
            placeholder="Nombre"
            required
          />
          <input
            class="input-datos-fit"
            type="text"
            name="email"
            placeholder="Apellido"
            required
          />
          <input
            class="input-datos-fit"
            type="text"
            name="profesion"
            placeholder="Profesion"
            required
          />
          <input
            class="input-datos-fit"
            type="text"
            name="empresa"
            placeholder="Empresa"
            required
          />
          <br />
          <input
            class="input-datos-fit"
            type="text"
            name="ubicacion"
            placeholder="Ubicacion"
            required
          />
          <input
            class="input-datos-fit"
            type="text"
            name="ciudad"
            placeholder="Ciudad"
            required
          />
          <input
            class="input-datos-fit"
            type="text"
            name="paginaweb"
            placeholder="Pagina Web"
            required
          />
          <br />
          <br />
          <Link to="/">
            <button class="boton-navegacion-perfil">Atras</button>
          </Link>
          <Link to="/">
            <button class="boton-navegacion-perfil">Aplicar Cambios</button>
          </Link>
        </div>
      </div>
    </div>
  );
}

export default PaginaPerfil;
