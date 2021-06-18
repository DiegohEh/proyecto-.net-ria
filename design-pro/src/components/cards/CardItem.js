import React from 'react';
import { Link } from 'react-router-dom';

function CardItem(props) {
    return (
        <>
            <li className='cards__item'>
                <Link className='cards__item__link' to={props.path}>
                    <figure className='cards__item__pic-wrap' data-category={props.category}>
                        <img src={props.src} alt='portada' className='cards__item__img' />
                    </figure>
                    <div className='cards__item__info'>
                        <h5 className='cards__item__text'>{props.text}</h5>
                    </div>
                    <div className='cards__item__cont__div'>
                        <hr className='cards__item__div'/>
                    </div>
                    <div className='cards__item__otherInfo'>
                        <h5 className='cards__item__views'><i class="far fa-eye"></i> {props.views}</h5>
                        <h5 className='cards__item__likes'><i class="far fa-thumbs-up"></i> {props.likes}</h5>
                    </div>
                </Link>
            </li>
        </>
    )
}

export default CardItem
