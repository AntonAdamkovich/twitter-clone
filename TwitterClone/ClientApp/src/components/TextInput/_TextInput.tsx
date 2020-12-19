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
  helperText?: string;
  name: string;
  placeholder?: string;
}

export type ITextInputProps = IOwnProps & TextFieldProps;

export default React.forwardRef<HTMLInputElement, ITextInputProps>(({ name, label, helperText, placeholder, ...props}, ref) => (
    <FormControl>
      <InputLabel htmlFor={`${name}-input`}>
        {label}
      </InputLabel>
      <Input
        name={name}
        ref={ref}
        id={`${name}-input`}
        placeholder={placeholder}
        aria-describedby={`${name}-input-text-helper-text`}
      />
      <FormHelperText id={`${name}-input-text-helper-text`}>
        {helperText}
      </FormHelperText>
    </FormControl>
  )
);
