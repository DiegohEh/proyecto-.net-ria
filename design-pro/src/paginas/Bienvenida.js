import logo from "../assets/logo.png";
import { Link } from "react-router-dom";

function PaginaBienvenida() {
  return (
    <div class="container-bienvenida">
      <div class="cuadro-bienvenida">
        <img src={logo} class="logo-redimensionado" />
        <span>DesignPro.</span>
        <h3>¡Bienvenido!</h3>
        <hr class="hr-bienvenida" />
        <input
          class="input-datos-fit"
          type="mail"
          name="email"
          placeholder="Email"
          required
        />
        <br />
        <input
          class="input-datos-fit"
          type="password"
          name="pass"
          placeholder="Contraseña"
          required
        />
        <br />
        <button type="submit" value="Submit" class="boton-registro">
          Ingresar
        </button>
        <br />
        <Link to='/registro'>
        <button
          class="boton-registro"
        >
          Registrate
        </button>
        </Link>
        <br />
        <a href="#" class="cambiar-contra">
          Ingresar como Invitado
        </a>
        <a href="#" class="cambiar-contra">
          ¿Olvidaste tu Contraseña?
        </a>
      </div>
    </div>
  );
}

export default PaginaBienvenida;
