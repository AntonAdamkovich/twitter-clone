import { createAction } from 'typesafe-actions';

import * as LoadingActionTypes from '../actionTypes/loading';

export const startLoading = createAction(LoadingActionTypes.START_LOADING)<undefined, undefined>();
export const finishLoading = createAction(LoadingActionTypes.FINISH_LOADING)<undefined, undefined>();
