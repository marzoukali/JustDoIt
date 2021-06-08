import { useField } from 'formik';
import React from 'react';
import { Form, Label, Select } from 'semantic-ui-react';

interface Props {
    placeholder: string;
    name: string;
    options: any;
    label?: string;
    onChange?: any;
}

export default function SelectInput(props: Props) {
    const [field, meta, helpers] = useField(props.name); 
    return (
        <Form.Field error={meta.touched && !!meta.error}>
            <label>{props.label}</label>
     
            {meta.touched && meta.error ? (
                <Label basic color='red'>{meta.error}</Label>
            ) : null}
        </Form.Field>
    )
}