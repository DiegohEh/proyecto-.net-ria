import { Route, Switch   } from "react-router-dom";

import Registro from "./paginas/Registro";
import Bienvenida from "./paginas/Bienvenida";
import Perfil from "./paginas/Perfil";
import AltaProyecto from "./paginas/AltaProyecto";

function App() {
  return (
    <div>
      <Switch>
        <Route path="/" exact>
          <Bienvenida />
        </Route>
        <Route path="/registro">
          <Registro />
        </Route>
        <Route path="/perfil">
          <Perfil />
        </Route>
        <Route path="/altaproyecto">
          <AltaProyecto />
        </Route>
      </Switch>
      </div>
  );
}

export default App;
