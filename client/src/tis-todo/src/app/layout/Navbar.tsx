import React from 'react';
import {Button, Container, Menu, MenuItem} from 'semantic-ui-react';
import { useStore } from '../stores/store';



export default function Navbar(){
    
    const {todoStore} = useStore();

    return (
        <Menu inverted fixed='top'>
            <Container>
                <MenuItem header>
                    <img src='/assets/logo.png' alt='JustDoIt' style={{marginRight: '10px'}}/>
                    JustDoIt
                </MenuItem>
                <Menu.Item name='TodoItems' />
                <Menu.Item>
                    <Button onClick={() => todoStore.openForm()} positive content="+" />
                </Menu.Item>
            </Container>
        </Menu>
    )
}