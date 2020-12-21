import { createAsyncAction } from 'typesafe-actions';

import * as RegistrationActionTypes from '../../actionTypes/pages/registration';
import { IRegistrationFormValues } from '../../pages/Registration/RegistrationForm/interfaces';

export const submitRegistrationAsync = createAsyncAction(
  RegistrationActionTypes.SUBMIT_REGISTRATION_REQUEST,
  RegistrationActionTypes.SUBMIT_REGISTRATION_SUCCESS,
  RegistrationActionTypes.SUBMIT_REGISTRATION_FAILURE,
)<IRegistrationFormValues, undefined, Error>();
