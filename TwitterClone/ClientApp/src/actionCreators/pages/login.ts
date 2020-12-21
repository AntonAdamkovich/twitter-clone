import { createAsyncAction } from 'typesafe-actions';

import * as LoginActionTypes from '../../actionTypes/pages/login';
import { ILoginFormValues } from '../../pages/Login/LoginForm/interfaces';

export const submitLoginAsync = createAsyncAction(
  LoginActionTypes.SUBMIT_LOGIN_REQUEST,
  LoginActionTypes.SUBMIT_LOGIN_SUCCESS,
  LoginActionTypes.SUBMIT_LOGIN_FAILURE,
)<ILoginFormValues, undefined, Error>();
