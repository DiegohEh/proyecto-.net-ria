import logo from "../assets/logo.png";
import { Link } from "react-router-dom";

function PaginaRegistro() {
  return (
    <div className="container">
      <div className="cuadro-bienvenida">
        <img src={logo} className="logo-redimensionado" />
        <span>DesignPro.</span>
        <h3>Crea tu Cuenta</h3>
        <hr className="hr-bienvenida" />
        <input
          className="input-datos-fit"
          type="mail"
          name="email"
          placeholder="Email"
          required
        />
        <br />
        <input
          className="input-datos-fit"
          type="text"
          name="nombre"
          placeholder="Nombre"
          required
        />
        <br></br>
        <input
          className="input-datos-fit"
          type="text"
          name="apellido"
          placeholder="Apellido"
          required
        />
        <br />
        <input
          className="input-datos-fit"
          type="password"
          name="pass"
          placeholder="Contraseña"
          required
        />
        <br />
        <input
          className="input-datos-fit"
          type="date"
          name="fecha"
          placeholder="Fecha de Nacimiento"
          required
        />
        <br />
        <select name="pais" className="input-datos-fit-pais" required>
          <option value="" disabled selected hidden>
            Pais de Residencia
          </option>
        </select>
        <br/>
        <button
          type="submit"
          value="Submit"
          onclick="window.location.href='https://www.w3docs.com';"
          className="boton-registro"
        >
          Registrate
        </button>
        <br />
        <Link to="/">
          <button class="boton-registro">Atras</button>
        </Link>
        <br />
        <br />
        <br />
      </div>
    </div>
  );
}

export default PaginaRegistro;
