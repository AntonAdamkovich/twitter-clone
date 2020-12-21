import React from 'react';

import {
  TextFieldProps,
  FormControl,
  Input,
  InputLabel,
  FormHelperText,
} from '@material-ui/core';

export interface IOwnProps {
  label?: string;
  name: string;
  errorMessage?: string;
  placeholder?: string;
}

export type ITextInputProps = IOwnProps & TextFieldProps;

export default React.forwardRef<HTMLInputElement, ITextInputProps>(({ name, label, errorMessage, placeholder, ...props}, ref) => (
    <FormControl error={!!errorMessage}>
      <InputLabel htmlFor={`${name}-input`}>
        {label}
      </InputLabel>
      <Input
        name={name}
        inputRef={ref}
        id={`${name}-input`}
        placeholder={placeholder}
        aria-describedby={`${name}-input-text-helper-text`}
      />
      <FormHelperText id={`${name}-input-text-helper-text`}>
        {errorMessage}
      </FormHelperText>
    </FormControl>
  )
);
