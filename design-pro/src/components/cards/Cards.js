import React from 'react';
import CardItem from './CardItem';
import './Cards.css';

function Cards() {
    return (
        <div className='cards'>
            <div className='cards__container'>
                <div className='cards__wrapper'>
                    <ul className='cards__items'>
                        <CardItem 
                            src='images/paisaje-2.jpeg'
                            text='Proyecto increíble y bonito'
                            category='Arte'
                            views='15123455'
                            likes='1023234'
                            path='/'
                        />
                        <CardItem 
                            src='images/paisaje-2.jpeg'
                            text='Proyecto increíble y bonito'
                            category='Arte'
                            views='15123455'
                            likes='1023234'
                            path='/'
                        />
                        <CardItem 
                            src='images/paisaje-2.jpeg'
                            text='Proyecto increíble y bonito'
                            category='Arte'
                            views='15123455'
                            likes='1023234'
                            path='/'
                        />
                    </ul>
                    <ul className='cards__items'>
                        <CardItem 
                            src='images/paisaje-2.jpeg'
                            text='Proyecto increíble y bonito'
                            category='Arte'
                            views='15123455'
                            likes='1023234'
                            path='/'
                        />
                        <CardItem 
                            src='images/paisaje-2.jpeg'
                            text='Proyecto increíble y bonito'
                            category='Arte'
                            views='15123455'
                            likes='1023234'
                            path='/'
                        />
                        <CardItem 
                            src='images/paisaje-2.jpeg'
                            text='Proyecto increíble y bonito'
                            category='Arte'
                            views='15123455'
                            likes='1023234'
                            path='/'
                        />
                    </ul>
                </div>
            </div>
            
        </div>
    )
}

export default Cards
