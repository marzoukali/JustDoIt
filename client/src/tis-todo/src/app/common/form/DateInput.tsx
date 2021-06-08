import { useField } from 'formik';
import DatePicker, {ReactDatePickerProps} from 'react-datepicker';
import { Form, Label } from 'semantic-ui-react';

interface Props {
    onChange?: any;
    name: string;
}

export default function DateInput(props: Props) {
    const [field, meta, helpers] = useField(props.name!); 
    return (
        <Form.Field error={meta.touched && !!meta.error}>
            <DatePicker 
                {...field}
                {...props}
                selected={(field.value && new Date(field.value)) || null}
                onChange={value => helpers.setValue(value)}
            />
            {meta.touched && meta.error ? (
                <Label basic color='red'>{meta.error}</Label>
            ) : null}
        </Form.Field>
    )
}