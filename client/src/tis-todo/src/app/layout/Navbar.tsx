import React from 'react';
import { NavLink } from 'react-router-dom';
import {Button, Container, Menu, MenuItem} from 'semantic-ui-react';
import { useStore } from '../stores/store';



export default function Navbar(){
    
    const {todoStore} = useStore();

    return (
        <Menu inverted fixed='top'>
            <Container>
                <MenuItem as={NavLink} to='/' exact header>
                    <img src='/assets/logo.png' alt='JustDoIt' style={{marginRight: '10px'}}/>
                    JustDoIt
                </MenuItem>
                <Menu.Item name='My Todos' as={NavLink} to='/dashboard' />
            </Container>
        </Menu>
    )
}