import * as LoadingActionTypes from '../actionTypes/loading';

import { IRootAction } from '../actionCreators';

export interface ILoadingState {
  isLoading: boolean;
}

export const initialState = {
  isLoading: false,
};

export function loading(state: ILoadingState = initialState, action: IRootAction): ILoadingState {
  switch (action.type) {
    case LoadingActionTypes.START_LOADING: {
      return {
        ...state,
        isLoading: true,
      };
    }

    case LoadingActionTypes.FINISH_LOADING: {
      return {
        ...state,
        isLoading: false,
      };
    }

    default: {
      return state;
    }
  }
}
