import React from 'react';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import './App.css';

// Components
import Navbar from './components/navbar/Navbar';
import SearchBar from './components/searchBar/SearchBar';
import Home from './components/pages/Home';

// Pages
import Registro from "./paginas/Registro";
import Bienvenida from "./paginas/Bienvenida";
import Perfil from "./paginas/Perfil";
import AltaProyecto from "./paginas/AltaProyecto";

function App() {
  return (
    <>  
      <Router>
        <Navbar />
        <SearchBar />
        <Switch>
          <Route path='/' exact component={Home} >
          </Route>
          <Route path="/ingreso" exact>
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
      </Router>
    </>
  );
}

export default App;