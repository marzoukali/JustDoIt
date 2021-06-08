import { observer } from 'mobx-react-lite';
import { Link, NavLink } from 'react-router-dom';
import { Button, Container, Menu, Image, Dropdown, MenuItem } from 'semantic-ui-react';
import { useStore } from '../stores/store';



export default observer(function Navbar(){
    
    const { userStore: { user, logout, isLoggedIn } } = useStore();

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} exact to='/' header>
                    <img src='/assets/logo.png' alt='logo' style={{ marginRight: '10px' }} />
                    JustDoIt
                </Menu.Item>
                {isLoggedIn &&
                <>
                <Menu.Item as={NavLink} to='/dashboard' name='My Todos' />
                <Menu.Item position='right'>
                    <Image src='/assets/user.png' avatar spaced='right' />
                    <Dropdown pointing='top left' text={user?.username}>
                        <Dropdown.Menu>
                            <Dropdown.Item as={Link} to={`/dashboard`} 
                                text='My Todos' icon='user' />
                            <Dropdown.Item onClick={logout} text='Logout' icon='power' />
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>
                </>}
               
            </Container>
        </Menu>
    )
})