import {Button, Header, Icon, Segment} from 'semantic-ui-react'
import { Link } from 'react-router-dom';


export default function NotFound(){

    return (
        <Segment placeholder>
            <Header icon>
                <Icon name='search' />
                Oops - Nothing has been found.
            </Header>
            <Segment.Inline>
                <Button as={Link} to='/' primary>
                    Return to home
                </Button>
            </Segment.Inline>
        </Segment>
    )
}