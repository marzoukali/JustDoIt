import React from 'react';
import {Button, Container, Menu, MenuItem} from 'semantic-ui-react';

export default function Navbar(){
    return (
        <Menu inverted fixed='top'>
            <Container>
                <MenuItem header>
                    <img src='/assets/logo.png' alt='JustDoIt' style={{marginRight: '10px'}}/>
                    JustDoIt
                </MenuItem>
                <Menu.Item name='TodoItems' />
                <Menu.Item>
                    <Button positive content="+" />
                </Menu.Item>
            </Container>
        </Menu>
    )
}