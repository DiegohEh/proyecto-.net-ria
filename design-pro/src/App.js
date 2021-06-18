import React from 'react';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import './App.css';

// Components
import Navbar from './components/navbar/Navbar';
import SearchBar from './components/searchBar/SearchBar';

// Pages
import Home from './components/pages/Home';

function App() {
  return (
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
  );
}

export default App;
