<<<<<<< HEAD
import React from 'react';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import './App.css';
=======
import { Route, Switch   } from "react-router-dom";

import Registro from "./paginas/Registro";
import Bienvenida from "./paginas/Bienvenida";
import Perfil from "./paginas/Perfil";
import AltaProyecto from "./paginas/AltaProyecto";
>>>>>>> plantillas-iniciales

// Components
import Navbar from './components/navbar/Navbar';
import SearchBar from './components/searchBar/SearchBar';

// Pages
import Home from './components/pages/Home';

function App() {
  return (
<<<<<<< HEAD
    <>  
      <Router>
        <Navbar />
        <SearchBar />
        <Switch>
          <Route path='/' exact component={Home} >
          </Route>
        </Switch>
      </Router>
    </>
=======
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
>>>>>>> plantillas-iniciales
  );
}

export default App;
