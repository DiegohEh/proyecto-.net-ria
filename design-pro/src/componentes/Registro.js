import logo from "../assets/logo.png";

function Registro() {
    return(
        <div className="container-registro">
      <div className="cuadro-bienvenida">
        <img src={logo} className="logo-redimensionado" />
        <span>DesignPro.</span>
        <h3>Crea tu Cuenta</h3>
        <hr className="hr-bienvenida" />
        <input
          className="input-registro-fit"
          type="mail"
          name="email"
          placeholder="Email"
          required
        />
        <br />
        <input
          className="input-registro"
          type="text"
          name="nombre"
          placeholder="Nombre"
          required
        />
        <input
          className="input-registro"
          type="text"
          name="apellido"
          placeholder="Apellido"
          required
        />
        <br />
        <input
          className="input-registro-fit"
          type="password"
          name="pass"
          placeholder="Contraseña"
          required
        />
        <br />
        <input
          className="input-registro-fit"
          type="date"
          name="fecha"
          placeholder="Fecha de Nacimiento"
          required
        />
        <br />
        <select name="pais" className="input-registro-fit-pais" required>
          <option value="" disabled selected hidden>
            Pais de Residencia
          </option>
        </select>
        <button
          type="submit"
          value="Submit"
          onclick="window.location.href='https://www.w3docs.com';"
          className="boton-registro"
        >
          Registrate
        </button>
        <br/>
        <br/>
      </div>
    </div>
    );
}

export default Registro;