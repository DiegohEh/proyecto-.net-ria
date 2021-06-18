import React, { useState } from 'react';
import './SearchBar.css';

const SearchBar = () => {

    const [search, setSearch] = useState('');

    const realizarBusqueda = (event) => {
        event.preventDefault();

        if(!search.trim()) {
            console.log('empty');
            return;
        } else {
            console.log(search);
        }

        event.target.reset();
        setSearch('');
    }

    return (
         <>
            <nav className='search-bar'>
                <div className='search-bar-container'>
                    <form className='search-bar-form' onSubmit={ realizarBusqueda } >
                        <div className='label-input'>Buscar Proyecto: </div>
                        <input 
                            type='text'
                            placeholder='¡Ingresa aquí tu búsqueda!'
                            onChange={ (e) => setSearch(e.target.value) }
                            className='search-input'
                        />
                        <button type='submit' className='search-submit'><i className='fa fa-search'>&nbsp;</i></button>
                    </form>
                </div>
            </nav>
        </>
    )
}

export default SearchBar
